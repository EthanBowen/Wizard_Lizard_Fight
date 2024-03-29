﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_Movement : MonoBehaviour
{

    //private bool shield;
    public float MovementSpeed = 5f;
    public float DiagonalMoveSpeedMultiplier = 1f;

    
    public float horizontal, vertical;
    Rigidbody2D Body;
    //public GameObject PlayerShield;


    // Singleton behavior
    /*private static _script_Movement _instance_Player01;
    private static _script_Movement _instance_Player02;
    private static _script_Movement _instance_Player03;
    private static _script_Movement _instance_Player04;
    */
    public int ID;

    // Awake is called before Start
    private void Awake()
    {
        /*
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
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        /*if (PlayerShield == null)
        {
            Debug.Log("error - couldn't find object for playershield");
        }
        */
        Body.freezeRotation = true;
        //shield = false;
    }


    private void MovePlayer()
    {
        
        Vector2 pos = Body.velocity;
        if (vertical != 0)
        {
            pos.y = MovementSpeed * Mathf.Sign(vertical);
        }
        else
        {
            pos.y = 0;
        }
        if (horizontal != 0)
        {
            pos.x = MovementSpeed * Mathf.Sign(horizontal);
        }
        else
        {
            pos.x = 0;
        }
        if (vertical != 0 && horizontal != 0)
        {
            //float average = Mathf.Sqrt(MovementSpeed);
            float average = Mathf.Sqrt(Mathf.Pow(horizontal, 2) + Mathf.Pow(vertical,2));
            pos.x = average * MovementSpeed * Mathf.Sign(horizontal);
            pos.y = average * MovementSpeed * Mathf.Sign(vertical);
        }

        Body.velocity = pos;
        return;
    }
    /*
    private void MovePlayer02()
    {

        Vector2 pos = Body.velocity;
        if (verticalP2 != 0)
        {
            pos.y = MovementSpeed * Mathf.Sign(verticalP2);
        }
        else
        {
            pos.y = 0;
        }
        if (horizontalP2 != 0)
        {
            pos.x = MovementSpeed * Mathf.Sign(horizontalP2);
        }
        else
        {
            pos.x = 0;
        }
        if (verticalP2 != 0 && horizontalP2 != 0)
        {
            float average = 
            pos.x = average * Mathf.Sign(horizontalP2);
            pos.y = average * Mathf.Sign(verticalP2);
        }

        Body.velocity = pos;
        return;
    }*/

    private void FixedUpdate()
    {
        //if (this == _instance_Player01)
        {
            MovePlayer();
        }
        /*
        if (this == _instance_Player02)
            MovePlayer02();*/
        //Abilities();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetAxisRaw("P1_horiz_dpad") != 0) {
            horizontalP1 = Input.GetAxisRaw("P1_horiz_dpad");
        }
        else if ((Input.GetAxisRaw("P1_horiz_left") != 0))
        {
            horizontalP1 = Input.GetAxisRaw("P1_horiz_left");
        }
        else
        {
            horizontalP1 = 0;
        }
        if (Input.GetAxisRaw("P1_vert_dpad") != 0)
        {
            verticalP1 = Input.GetAxisRaw("P1_vert_dpad");
        }
        else if ((Input.GetAxisRaw("P1_vert_left") != 0))
        {
            verticalP1 = Input.GetAxisRaw("P1_vert_left");
        }
        else
        {
            verticalP1 = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shield = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shield = false;
        }*/

        /*
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


        */

    }

    /*
     * Called when the lower face button "A" button is pressed.
     */
    public void button_lower()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"A\" pressed");
        return;
    }

    /*
    * Called when the lower face button "A" button is pressed.
    */
    public void button_right()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"B\" pressed");
        return;
    }

    /*
    * Called when the lower face button "A" button is pressed.
    */
    public void button_left()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"X\" pressed");
        return;
    }

    /*
    * Called when the lower face button "A" button is pressed.
    */
    public void button_up()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"Y\" pressed");
        return;
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
