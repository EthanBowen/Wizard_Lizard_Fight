using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class _script_SceneController_v02 : MonoBehaviour
{
    public int NumberOfPlayers = 2;
    public GameObject PlayerObject;
    public float PlayerMovementSpeed = 5f;
    public float CameraZoomDefault = 5f;
    public float CameraZoomOffset = 5f;
    public float CameraZoomDefaultMin = 5f;
    public float CameraZoomDefaultMax = 15f;


    // Keep track of all the controllers
    private _script_ReadInputs PlayerInputs;

    // Keep track of the player objects & other player related items
    private Dictionary<int, GameObject> ListOfPlayers;
    private Dictionary<int, int> ListOfScores;
    private int winner = 0;

    // Player spawn locations
    public List<Vector2> PlayerSpawnLocations;

    // Provide access to the camera object this script is attached to.
    private Camera camera;

    // music_main is the AudioSource through which music will play.
    // music_main (and AudioSources in general) *play* AudioClips. They're the speaker, so to speak.
    public bool PlayMusicOnPlay = true;
    public AudioSource music_main;
    public AudioClip music_battle;
    private bool music_play;

    // Event system WIP 
    public DebugModeEvent event_DebugModeEvent;


    // Singleton behavior
    private static _script_SceneController_v02 _instance_SceneController;
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

        PlayerInputs = new _script_ReadInputs();


        ListOfPlayers = new Dictionary<int, GameObject>();
        ListOfScores = new Dictionary<int, int>();
        for (int index = 1; index <= NumberOfPlayers; ++index)
        {
            GameObject character = Instantiate(PlayerObject);

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
            character_script.inputs = new _script_ReadInputs(index);
            ListOfPlayers.Add(index, character);
            ListOfScores.Add(index, 0);

            PlayerInput actmap = character.GetComponent<PlayerInput>();
            if (actmap != null)
            {
                Debug.Log("Successfully captured actmap: " + index + " - with Index: " + actmap.playerIndex);
                
               // InputDevice 
                Debug.Log("Paired Devices: ");
                
            }
            else
            {
                Debug.Log("No actmap grabbed: " + index);
            }
            

        }

        // Sets the music player to play the battle music.
        music_main.clip = music_battle;
        if (PlayMusicOnPlay) {
            music_main.loop = true;
            music_main.Play();
        }
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        // Reset's the FocusPoints on the players
        PlayerPositions.Clear();
        // Iterates through each player and transmits input actions
        for (int index = 1; index <= NumberOfPlayers; ++index)
        {
            PlayerInputs.ReadPlayerInputs(index);
            Player playercontroller = ListOfPlayers[index].GetComponent<Player>();
            if (playercontroller != null)
            {
                // Restart the scene by pressing start
                if (PlayerInputs.button_start)
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



    private List<Vector2> FocusPoints;
    private List<Vector2> PlayerPositions;
    private float cam_size, x_dist_min, x_dist_max, y_dist_min, y_dist_max, x_dist, y_dist;

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

        camera.transform.position = new Vector3(((x_dist_max + x_dist_min)/2), ((y_dist_max + y_dist_min)/2), -10);
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


    public void OnPlayerJoined(PlayerInput playerJoin)
    {
        Debug.Log("CONTROLLER LOGGED: " + playerJoin.playerIndex);
        
    }


}
