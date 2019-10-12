using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_SceneController_v01 : MonoBehaviour
{
    public int NumberOfPlayers = 2;
    public GameObject PlayerObject;

    // Keep track of all the controllers

    // Keep track of the player objects
    private List<GameObject> ListOfPlayers;

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
        ListOfPlayers = new List<GameObject>();
        for (int index = 0; index < NumberOfPlayers; ++index)
        {
            GameObject character = Instantiate(PlayerObject);
            Vector3 spawnpoint = new Vector3(index * 2 - 1, index * 2 - 1);
            character.transform.position = spawnpoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
