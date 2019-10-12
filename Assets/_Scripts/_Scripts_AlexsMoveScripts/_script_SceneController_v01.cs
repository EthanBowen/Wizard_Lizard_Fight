using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_SceneController_v01 : MonoBehaviour
{
    // Keep track of all the controllers

    // Keep track of the player objects

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
