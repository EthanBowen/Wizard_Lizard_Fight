using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public int NumberOfPlayers = 2;
    public GameObject PlayerObject;
    public GameObject healthObject;
    public float PlayerMovementSpeed = 5f;
    public float CameraZoomDefault = 5f;
    public float CameraZoomOffset = 5f;
    public float CameraZoomDefaultMin = 5f;
    public float CameraZoomDefaultMax = 15f;

    private int winner = 0;

    // Keep track of all the controllers

    // Keep track of the player objects
    private Dictionary<int, GameObject> ListOfPlayers;

    private Dictionary<int, int> ListOfScores;

    // Player spawn locations
    public List<Vector2> PlayerSpawnLocations;

    // Provide access to the camera object this script is attached to.
    private Camera camera;

    // music_main is the AudioSource through which music will play.
    // music_main (and AudioSources in general) *play* AudioClips. They're the speaker, so to speak.
    public AudioSource music_main;
    public AudioClip music_battle;
    private bool music_play;

    // Event system WIP 
    public DebugModeEvent event_DebugModeEvent;


    // Singleton behavior
    private static GameController _instance_SceneController;
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

        camera = gameObject.GetComponent<Camera>();
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
        FocusPoints = new List<Vector2>();
        PlayerPositions = new List<Vector2>();

        GameObject[] respawns = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");

        List<Vector3> spawnpoints = new List<Vector3>();
        foreach (GameObject spawn in respawns)
        {
            spawnpoints.Add(spawn.transform.position);
        }

        InstantiatePlayerInputList();
        ListOfPlayers = new Dictionary<int, GameObject>();
        ListOfScores = new Dictionary<int, int>();
        for (int index = 1; index <= NumberOfPlayers; ++index)
        {
            GameObject character = Instantiate(PlayerObject);
            GameObject health = Instantiate(healthObject);

            Vector3 spawnpoint;
            if (!(spawnpoints.Count < NumberOfPlayers))
                spawnpoint = spawnpoints[index - 1];
            else
                spawnpoint = new Vector3(index - 1, index - 1);

            //Vector3 spawnpoint = new Vector3(index * 2 - 1, index * 2 - 1);
            //character.transform.position = spawnpoint;
            Player character_script = character.GetComponent<Player>();

            character_script.SpawnPoint = spawnpoint;
            character_script.movementSpeed = PlayerMovementSpeed;
            character.GetComponent<Player>().ID = index;
            health.GetComponent<HealthBar>().ID = index;
            health.GetComponent<HealthBar>().player = character.GetComponent<Player>();
            character_script.inputs = new _script_ReadInputs(index);
            ListOfPlayers.Add(index, character);
            ListOfScores.Add(index, 0);
            /*
             * This was initially to spawn the healthbars for the characters
            switch(index)
            {
                case 1:
                    health.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
                    break;
                case 2:
                    health.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
                    break;
                case 3:
                    health.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
                    break;
                case 4:
                    health.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
                    break;
            }
            */

        }

        // Sets the music player to play the battle music.
        music_main.clip = music_battle;
        music_main.loop = true;
        music_main.Play();
    }

    /* INPUTS FOR EACH PLAYER */
    private float PLAYER_horiz_move, PLAYER_vert_move, PLAYER_horiz_aim, PLAYER_vert_aim;
    private bool button_lower, button_left, button_right, button_up, button_select, button_start;
    private bool button_lower_stop, button_left_stop, button_right_stop, button_up_stop;

    private List<Vector2> FocusPoints;
    private List<Vector2> PlayerPositions;
    float cam_size, x_dist_min, x_dist_max, y_dist_min, y_dist_max, x_dist, y_dist;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Reset's the FocusPoints on the players
        PlayerPositions.Clear();
        // Iterates through each player and transmits input actions
        for (int index = 1; index <= NumberOfPlayers; ++index)
        {
            ReadPlayerInputs(index);
            Player playercontroller = ListOfPlayers[index].GetComponent<Player>();
            if (playercontroller != null)
            {
                /*
                playercontroller.horizontal = PLAYER_horiz_move;
                playercontroller.vertical = PLAYER_vert_move;
                playercontroller.MovePlayer();// PLAYER_horiz_move, PLAYER_vert_move);
                /// TODO: Convert this functionality into an event-based system?
                if (button_lower)
                {
                    playercontroller.StartWind();
                }
                if (button_lower_stop)
                {
                    playercontroller.StopWind();
                }
                if (button_right)
                {
                    playercontroller.StartFire();
                }
                if (button_right_stop)
                {
                    playercontroller.StopFire();
                }
                    
                //playercontroller.CastMagic(button_lower, button_left, button_right, button_up);
                */
                // Restart the scene by pressing start
                if (button_start)
                {
                    SceneManager.LoadScene("Game");
                }

                // TODO: Move to event based system.
                if (playercontroller.score >= 5)
                {
                    winner = playercontroller.ID;
                    SceneManager.LoadScene("GameEnd");
                }

                // Add the player's new position as a FocusPoint for the camera
                PlayerPositions.Add(new Vector2(playercontroller.transform.position.x, playercontroller.transform.position.y));
            }
        }

        CameraMovement(PlayerPositions);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("winner", winner);
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
        foreach (Vector2 others in FocusPoints)
        {
            AdditionalFocusPoints.Add(others);
        }
        x_dist_min = y_dist_min = 10000f;
        x_dist_max = y_dist_max = -10000f;
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
        }

        cam_size = 0;
        x_dist = (x_dist_max - x_dist_min) * (9f / 16f);
        y_dist = (y_dist_max - y_dist_min);

        camera.transform.position = new Vector3(((x_dist_max + x_dist_min) / 2), ((y_dist_max + y_dist_min) / 2), -10);
        if ((x_dist) > (y_dist))
            cam_size = x_dist;
        else
            cam_size = y_dist;

        cam_size += CameraZoomOffset;
        cam_size /= 2;

        if (cam_size < CameraZoomDefaultMin)
        {
            cam_size = CameraZoomDefaultMin;
        }
        if (cam_size > CameraZoomDefaultMax)
        {
            cam_size = CameraZoomDefaultMax;
        }

        camera.orthographicSize = cam_size;
        return;
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
        button_lower = Input.GetButtonDown((InputNames[PlayerInputList])[4]);
        button_left = Input.GetButtonDown((InputNames[PlayerInputList])[5]) ? true : false;
        button_right = Input.GetButtonDown((InputNames[PlayerInputList])[6]) ? true : false;
        button_up = Input.GetButtonDown((InputNames[PlayerInputList])[7]) ? true : false;
        button_select = Input.GetButtonDown((InputNames[PlayerInputList])[8]) ? true : false;
        button_start = Input.GetButtonDown((InputNames[PlayerInputList])[9]) ? true : false;

        /* BUTTON Releases */
        button_lower_stop = Input.GetButtonUp((InputNames[PlayerInputList])[4]) ? true : false;
        button_left_stop = Input.GetButtonUp((InputNames[PlayerInputList])[5]) ? true : false;
        button_right_stop = Input.GetButtonUp((InputNames[PlayerInputList])[6]) ? true : false;
        button_up_stop = Input.GetButtonUp((InputNames[PlayerInputList])[7]) ? true : false;

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


    private PlayerInputsEvent event_playerinput;
    /**
     * Sets up the event system for player inputs based on the given ID.
     * NOTE: This is unused stuff, but is a good example for setting up events from the caller side.
     */
    private void Initialization_SetUpEventSystemFor_PlayerInputs(int playerID, Player player)
    {
        if (event_playerinput == null)
        {
            event_playerinput = new PlayerInputsEvent();
        }


        event_playerinput.AddListener(player.event_input_Wind);
    }

}

