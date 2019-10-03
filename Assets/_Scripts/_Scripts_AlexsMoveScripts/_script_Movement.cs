using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_Movement : MonoBehaviour
{

    //private bool shield;
    public float MovementSpeed = 0.5f;
    public float DiagonalMoveSpeedMultiplier = 1f;
    private float horizontal, vertical;
    Rigidbody2D Body;
    //public GameObject PlayerShield;


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
            float average = MovementSpeed / 2;
            pos.x = average * Mathf.Sign(horizontal);
            pos.y = average * Mathf.Sign(vertical);
        }

        Body.velocity = pos;
        return;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        //Abilities();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shield = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shield = false;
        }*/
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
