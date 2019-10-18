using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DebugModeEvent : UnityEvent<bool>
{

};

public class _script_SceneController_v01 : MonoBehaviour
{
    public int NumberOfPlayers = 2;
    public GameObject PlayerObject;
    public float PlayerMovementSpeed = 5f;
    public float CameraZoomDefault = 5f;
    public float CameraZoomOffset = 5f;
    public float CameraZoomDefaultMin = 5f;
    public float CameraZoomDefaultMax = 15f;

    // music_main is the AudioSource through which music will play.
    // music_main (and AudioSources in general) *play* AudioClips. They're the speaker, so to speak.
    public AudioSource music_main;
    public AudioClip music_battle;
    private bool music_play;

    // Player spawn locations
    public List<Vector2> PlayerSpawnLocations;

    // Keep track of the player objects
    private Dictionary<int, GameObject> ListOfPlayers;

    // Provide access to the camera object this script is attached to.
    private Camera camera;

    public DebugModeEvent event_DebugModeEvent;
    

    // Singleton behavior
    private static _script_SceneController_v01 _instance_SceneController;
    // Awake is called before Start
    private void Awake()
    {
        if (_instance_SceneController != null && _instance_SceneController != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance_SceneController = this;
        }

        camera = GetComponent<Camera>();
        if (camera == null)
        {
            Destroy(this.gameObject);
            Debug.Log("Scene Controller script must be attached to a camera");
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        Initialization_SetUpEventSystemFor_HideableSprites();

        HotfixTimer = 0;
        FocusPoints = new List<Vector2>();
        PlayerPositions = new List<Vector2>();
        
        // Sets the music player to play the battle music.
        music_main.clip = music_battle;
        music_main.loop = true;
        music_main.Play();

        GameObject[] respawns = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");

        List<Vector3> spawnpoints = new List<Vector3>();
        foreach(GameObject spawn in respawns)
        {
            spawnpoints.Add(spawn.transform.position);
        }

        InstantiatePlayerInputList();
        ListOfPlayers = new Dictionary<int, GameObject>();
        for (int index = 0; index < NumberOfPlayers; ++index)
        {
            GameObject character = Instantiate(PlayerObject);
            Vector3 spawnpoint;
            if (!(spawnpoints.Count < NumberOfPlayers))
                spawnpoint = spawnpoints[index];
            else
                spawnpoint = new Vector3(index, index);
            character.transform.position = spawnpoint;
            _script_Movement character_script = character.GetComponent<_script_Movement>();
            character_script.MovementSpeed = PlayerMovementSpeed;
            character.GetComponent<_script_Movement>().ID = index + 1;
            ListOfPlayers.Add(index + 1, character);
        }
    }

    /* INPUTS FOR EACH PLAYER */
    private float PLAYER_horiz_move, PLAYER_vert_move, PLAYER_horiz_aim, PLAYER_vert_aim;
    private bool button_lower, button_left, button_right, button_up, button_select, button_start;

    private List<Vector2> FocusPoints;
    private List<Vector2> PlayerPositions;
    float x_sum, y_sum, cam_size, x_dist_min, x_dist_max, y_dist_min, y_dist_max, x_dist, y_dist;
    int numPoints;
    int HotfixTimer;

    private bool DebugModeToggle = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Flips the toggle
            DebugModeToggle = !DebugModeToggle;
            // Calls the event.
            event_DebugModeEvent.Invoke(DebugModeToggle);
        }

        PlayerPositions.Clear();
        // Iterates through each player and transmits input actions
        for (int index = 1; index <= NumberOfPlayers; ++index)
        {
            ReadPlayerInputs(index);
            _script_Movement playercontroller = ListOfPlayers[index].GetComponent<_script_Movement>();
            if (playercontroller != null)
            {
                playercontroller.horizontal = PLAYER_horiz_move;
                playercontroller.vertical = PLAYER_vert_move;
                /// TODO: Convert this functionality into an event-based system?
                if (button_lower)
                    playercontroller.button_lower();
                if (button_right)
                    playercontroller.button_right();
                if (button_left)
                    playercontroller.button_left();
                if (button_up)
                    playercontroller.button_up();
                // Restart the scene by pressing start
                if (button_start)
                {
                    music_main.Stop();
                    SceneManager.LoadScene("_Scene_AlexTestEnviron");
                }

                PlayerPositions.Add(new Vector2(playercontroller.transform.position.x, playercontroller.transform.position.y));
            }
        }
        CameraMovement(PlayerPositions);
    }


    /*
     * Reads the list of points of focus the camera is based upon.
     * 
     * Input list is the list of dynamic objects that change frequently.
     * TODO: fix how the input vectors are determined.
     */
    private void CameraMovement(List<Vector2> AdditionalFocusPoints)
    {
        // AdditionalFocusPoints is expected to be remade.
        foreach(Vector2 others in FocusPoints)
        {
            AdditionalFocusPoints.Add(others);
        }

        x_sum = y_sum = 0f;
        x_dist_min = y_dist_min = 10000f;
        x_dist_max = y_dist_max = -10000f;
        numPoints = 0;
        // Move the camera so that it's focused on the center of the focus points.
        foreach (Vector2 point in AdditionalFocusPoints)
        {
            // min/max distance between points
            if (x_dist_min > point.x)
                x_dist_min = point.x;
            if (x_dist_max < point.x)
                x_dist_max = point.x;
            if (y_dist_min > point.y)
                y_dist_min = point.y;
            if (y_dist_max < point.y)
                y_dist_max = point.y;

            // Distance between all points
            x_sum += point.x;
            y_sum += point.y;
            numPoints++;
        }

        cam_size = 0;
        camera.transform.position = new Vector3((x_sum / numPoints), (y_sum / numPoints), -10);
        x_dist = (x_dist_max - x_dist_min) * (9f / 16f);
        y_dist = (y_dist_max - y_dist_min);
        if ((x_dist) > (y_dist))
            cam_size = x_dist;
        else
            cam_size = y_dist;

        cam_size += CameraZoomOffset;
        cam_size /= 2;

        if (cam_size < CameraZoomDefaultMin)
        {
            if (HotfixTimer >= 120)
            {
                Debug.Log("---- Cam Size set to minimum. cam size previously: " + cam_size);
            }
            cam_size = CameraZoomDefaultMin;
        }
        if (cam_size > CameraZoomDefaultMax)
        {
            if (HotfixTimer >= 120)
            {
                Debug.Log("---- Cam Size set to MAX. cam size previously: " + cam_size);
            }
            cam_size = CameraZoomDefaultMax;
        }

        camera.orthographicSize = cam_size;

        /*
        if (HotfixTimer >= 120)
        {
            Debug.Log("x difference: " + x_dist + " ---- y difference: " + y_dist);
            Debug.Log("Camera Size: " + cam_size + " versus: " + camera.orthographicSize);
            HotfixTimer = 0;
        }
        HotfixTimer++;*/
    }

    /**
     * Reads the player's inputs.
     * 
     * int PlayerInputList --- The player whose inputs are being read.
     */
    private void ReadPlayerInputs(int PlayerInputList)
    {
        /* MOVEMENT */
        // Horizontal movement
        if (Input.GetAxisRaw((InputNames[PlayerInputList])[1]) != 0)
        {
            PLAYER_horiz_move = Input.GetAxisRaw((InputNames[PlayerInputList])[1]);
        }
        else if ((Input.GetAxisRaw((InputNames[PlayerInputList])[0]) != 0))
        {
            PLAYER_horiz_move = Input.GetAxisRaw((InputNames[PlayerInputList])[0]);
        }
        else
        {
            PLAYER_horiz_move = 0;
        }
        // Vertical movement
        if (Input.GetAxisRaw((InputNames[PlayerInputList])[3]) != 0)
        {
            PLAYER_vert_move = Input.GetAxisRaw((InputNames[PlayerInputList])[3]);
        }
        else if ((Input.GetAxisRaw((InputNames[PlayerInputList])[2]) != 0))
        {
            PLAYER_vert_move = Input.GetAxisRaw((InputNames[PlayerInputList])[2]);
        }
        else
        {
            PLAYER_vert_move = 0;
        }

        // Right stick aiming
        // Horizontal aim
        if (Input.GetAxisRaw((InputNames[PlayerInputList])[10]) != 0)
        {
            PLAYER_horiz_aim = Input.GetAxisRaw((InputNames[PlayerInputList])[10]);
        }
        else
        {
            PLAYER_horiz_aim = 0;
        }
        // Vertical aim
        if (Input.GetAxisRaw((InputNames[PlayerInputList])[11]) != 0)
        {
            PLAYER_vert_aim = Input.GetAxisRaw((InputNames[PlayerInputList])[11]);
        }
        else
        {
            PLAYER_vert_aim = 0;
        }

        /* BUTTON PRESSES */
        button_lower = Input.GetButtonDown((InputNames[PlayerInputList])[4]) ? true : false;
        button_left = Input.GetButtonDown((InputNames[PlayerInputList])[5]) ? true : false;
        button_right = Input.GetButtonDown((InputNames[PlayerInputList])[6]) ? true : false;
        button_up = Input.GetButtonDown((InputNames[PlayerInputList])[7]) ? true : false;
        button_select = Input.GetButtonDown((InputNames[PlayerInputList])[8]) ? true : false;
        button_start = Input.GetButtonDown((InputNames[PlayerInputList])[9]) ? true : false;

        return;
    }

    /**
     * InputNames<Player, ListOfInputs<TypeOfInput, InputString>>
     */
    Dictionary<int, Dictionary<int, string>> InputNames;

    /**
     * Consolidates all references to player inputs into this list, allowing for super-easy changing of input names in one location
     */
    private void InstantiatePlayerInputList()
    {
        InputNames = new Dictionary<int, Dictionary<int, string>>();

        // Player 1's input list
        Dictionary<int, string> P1_Inputlist = new Dictionary<int, string>
        {
            [0] = "P1_horiz_left",
            [1] = "P1_horiz_dpad",
            [2] = "P1_vert_left",
            [3] = "P1_vert_dpad",
            [4] = "P1_button_down",
            [5] = "P1_button_left",
            [6] = "P1_button_right",
            [7] = "P1_button_up",
            [8] = "P1_button_select",
            [9] = "P1_button_start",
            [10] = "P1_horiz_right",
            [11] = "P1_vert_right"
        };

        InputNames[1] = P1_Inputlist;

        // Player 2's input list
        Dictionary<int, string> P2_Inputlist = new Dictionary<int, string>
        {
            [0] = "P2_horiz_left",
            [1] = "P2_horiz_dpad",
            [2] = "P2_vert_left",
            [3] = "P2_vert_dpad",
            [4] = "P2_button_down",
            [5] = "P2_button_left",
            [6] = "P2_button_right",
            [7] = "P2_button_up",
            [8] = "P2_button_select",
            [9] = "P2_button_start",
            [10] = "P2_horiz_right",
            [11] = "P2_vert_right"
        };

        InputNames[2] = P2_Inputlist;

        // Player 3's input list
        Dictionary<int, string> P3_Inputlist = new Dictionary<int, string>
        {
            [0] = "P3_horiz_left",
            [1] = "P3_horiz_dpad",
            [2] = "P3_vert_left",
            [3] = "P3_vert_dpad",
            [4] = "P3_button_down",
            [5] = "P3_button_left",
            [6] = "P3_button_right",
            [7] = "P3_button_up",
            [8] = "P3_button_select",
            [9] = "P3_button_start",
            [10] = "P3_horiz_right",
            [11] = "P3_vert_right"
        };

        InputNames[3] = P3_Inputlist;

        // Player 4's input list
        Dictionary<int, string> P4_Inputlist = new Dictionary<int, string>
        {
            [0] = "P4_horiz_left",
            [1] = "P4_horiz_dpad",
            [2] = "P4_vert_left",
            [3] = "P4_vert_dpad",
            [4] = "P4_button_down",
            [5] = "P4_button_left",
            [6] = "P4_button_right",
            [7] = "P4_button_up",
            [8] = "P4_button_select",
            [9] = "P4_button_start",
            [10] = "P4_horiz_right",
            [11] = "P4_vert_right"
        };

        InputNames[4] = P4_Inputlist;
    }


    /**
     * Some objects have developer sprites (like spawn points). These should have scripts attached that control their visibility during gameplay.
     * This will enable the notification system for those objects, so that we can control when they're visible/invisible.
     */
    private void Initialization_SetUpEventSystemFor_HideableSprites()
    {
        if (event_DebugModeEvent == null)
        {
            event_DebugModeEvent = new DebugModeEvent();
        }
        _script_DisableSpriteDuringGameplay[] HideableSprites = FindObjectsOfType<_script_DisableSpriteDuringGameplay>();
        foreach (_script_DisableSpriteDuringGameplay grabbedscript in HideableSprites)
        {
            event_DebugModeEvent.AddListener(grabbedscript.event_DebugMode);
        }

    }

}
