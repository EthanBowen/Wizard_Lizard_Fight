using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float horizontalP1, verticalP1, horizontalP2, verticalP2;
    //public GameObject PlayerShield;


    // Singleton behavior
    private static PlayerAttack _instance_Player01;
    private static PlayerAttack _instance_Player02;
    private static PlayerAttack _instance_Player03;
    private static PlayerAttack _instance_Player04;

    // Awake is called before Start
    private void Awake()
    {
        // Initialize which player owns this
        if (_instance_Player01 == null || _instance_Player01 == this)
        {
            _instance_Player01 = this;
        }
        else if (_instance_Player02 == null || _instance_Player02 == this)
        {
            _instance_Player02 = this;
        }
        else if (_instance_Player03 == null || _instance_Player03 == this)
        {
            _instance_Player03 = this;
        }
        else if (_instance_Player04 == null || _instance_Player04 == this)
        {
            _instance_Player04 = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (this == _instance_Player01)
        {

        }

        if (this == _instance_Player02)
        {

        }

        //Abilities();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalP1 = Input.GetAxisRaw("P1_horiz_left");
        verticalP1 = Input.GetAxisRaw("P1_vert_left");
        horizontalP2 = Input.GetAxisRaw("P2_horiz_left");
        verticalP2 = Input.GetAxisRaw("P2_vert_left");
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shield = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shield = false;
        }*/

        if (Input.GetButtonDown("P1_button_start"))
        {
            Debug.Log("[PLAYER 1] Button \"START\" pressed");
        }
        if (Input.GetButtonDown("P1_button_select"))
        {
            Debug.Log("[PLAYER 1] Button \"SELECT\" pressed");
        }
        if (Input.GetButtonDown("P1_button_down"))
        {
            Debug.Log("[PLAYER 1] Button \"A\" pressed");
        }
        if (Input.GetButtonDown("P1_button_right"))
        {
            Debug.Log("[PLAYER 1] Button \"B\" pressed");
        }
        if (Input.GetButtonDown("P1_button_left"))
        {
            Debug.Log("[PLAYER 1] Button \"X\" pressed");
        }
        if (Input.GetButtonDown("P1_button_up"))
        {
            Debug.Log("[PLAYER 1] Button \"Y\" pressed");
        }


        if (Input.GetButtonDown("P2_button_start"))
        {
            Debug.Log("---[PLAYER 2] Button \"START\" pressed");
        }
        if (Input.GetButtonDown("P2_button_select"))
        {
            Debug.Log("---[PLAYER 2] Button \"SELECT\" pressed");
        }
        if (Input.GetButtonDown("P2_button_down"))
        {
            Debug.Log("---[PLAYER 2] Button \"A\" pressed");
        }
        if (Input.GetButtonDown("P2_button_right"))
        {
            Debug.Log("---[PLAYER 2] Button \"B\" pressed");
        }
        if (Input.GetButtonDown("P2_button_left"))
        {
            Debug.Log("---[PLAYER 2] Button \"X\" pressed");
        }
        if (Input.GetButtonDown("P2_button_up"))
        {
            Debug.Log("---[PLAYER 2] Button \"Y\" pressed");
        }




    }

    //private GameObject shieldup;
    /*
    private void Abilities()
    {
        if (shield)
        {
            if (shieldup == null)
            {
                shieldup = Instantiate(PlayerShield, transform);
            }
            else
            {
                shieldup.transform.position = transform.position;
            }
        }
        else
        {
            if (shieldup != null)
            {
                Destroy(shieldup);
                shieldup = null;
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {

    }



}