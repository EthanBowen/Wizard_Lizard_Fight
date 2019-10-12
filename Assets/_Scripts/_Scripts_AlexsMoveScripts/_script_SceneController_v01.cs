using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_SceneController_v01 : MonoBehaviour
{
    public int NumberOfPlayers = 2;
    public GameObject PlayerObject;

    // Keep track of all the controllers

    // Keep track of the player objects
    private Dictionary<int, GameObject> ListOfPlayers;

    // 

    // 



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
    }


    // Start is called before the first frame update
    void Start()
    {
        InstantiatePlayerInputList();
        ListOfPlayers = new Dictionary<int, GameObject>();
        for (int index = 0; index < NumberOfPlayers; ++index)
        {
            GameObject character = Instantiate(PlayerObject);
            Vector3 spawnpoint = new Vector3(index * 2 - 1, index * 2 - 1);
            character.transform.position = spawnpoint;
            character.GetComponent<_script_Movement>().ID = index + 1;
            ListOfPlayers.Add(index + 1, character);
        }
    }

    private float P1_horiz_move, P1_vert_move;
    private bool button_lower;

    // Update is called once per frame
    void Update()
    {
        _script_Movement playercontroller = null;
        for (int index = 1; index <= NumberOfPlayers; ++index)
        {
            switch (index) {
                case (1):
                    ReadPlayerInputs(index);
                    playercontroller = ListOfPlayers[index].GetComponent<_script_Movement>();
                    if (playercontroller != null)
                    {
                        playercontroller.horizontal = P1_horiz_move;
                        playercontroller.vertical = P1_vert_move;
                        /// TODO: Convert this functionality into an event-based system?
                        if (button_lower)
                            playercontroller.button_lower();
                    }
                    break;
                case (2):
                    ReadPlayerInputs(index);
                    playercontroller = ListOfPlayers[index].GetComponent<_script_Movement>();
                    if (playercontroller != null)
                    {
                        playercontroller.horizontal = P1_horiz_move;
                        playercontroller.vertical = P1_vert_move;
                        /// TODO: Convert this functionality into an event-based system?
                        if (button_lower)
                            playercontroller.button_lower();
                    }
                    break;
                default:
                    break;
            }
        }

    }

    /**
     * Reads the player's inputs.
     * 
     * int PlayerInputList --- The player whose inputs are being read.
     */
    private void ReadPlayerInputs(int PlayerInputList)
    {
        /* MOVEMENT */
        if (Input.GetAxisRaw((InputNames[PlayerInputList])[1]) != 0)
        {
            P1_horiz_move = Input.GetAxisRaw((InputNames[PlayerInputList])[1]);
        }
        else if ((Input.GetAxisRaw((InputNames[PlayerInputList])[0]) != 0))
        {
            P1_horiz_move = Input.GetAxisRaw((InputNames[PlayerInputList])[0]);
        }
        else
        {
            P1_horiz_move = 0;
        }
        if (Input.GetAxisRaw((InputNames[PlayerInputList])[3]) != 0)
        {
            P1_vert_move = Input.GetAxisRaw((InputNames[PlayerInputList])[3]);
        }
        else if ((Input.GetAxisRaw((InputNames[PlayerInputList])[2]) != 0))
        {
            P1_vert_move = Input.GetAxisRaw((InputNames[PlayerInputList])[2]);
        }
        else
        {
            P1_vert_move = 0;
        }

        /* BUTTON PRESSES */
        button_lower = Input.GetButtonDown((InputNames[PlayerInputList])[4]) ? true : false;

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
        Dictionary<int, string> P1_Inputlist = new Dictionary<int, string>();
        P1_Inputlist[0] = "P1_horiz_left";
        P1_Inputlist[1] = "P1_horiz_dpad";
        P1_Inputlist[2] = "P1_vert_left";
        P1_Inputlist[3] = "P1_vert_dpad";
        P1_Inputlist[4] = "P1_button_down";

        InputNames[1] = P1_Inputlist;

        // Player 2's input list
        Dictionary<int, string> P2_Inputlist = new Dictionary<int, string>();
        P2_Inputlist[0] = "P2_horiz_left";
        P2_Inputlist[1] = "P2_horiz_dpad";
        P2_Inputlist[2] = "P2_vert_left";
        P2_Inputlist[3] = "P2_vert_dpad";
        P2_Inputlist[4] = "P2_button_down";

        InputNames[2] = P2_Inputlist;

    }

}
