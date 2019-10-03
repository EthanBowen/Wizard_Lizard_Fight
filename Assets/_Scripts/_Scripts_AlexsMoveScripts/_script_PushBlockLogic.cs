using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _script_PushBlockLogic : MonoBehaviour
{
    Rigidbody2D body;
    public bool left = false;
    public bool right = false;
    public bool up = false;
    public bool down = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int hitpoints = collision.contactCount;
        // Debug.Log("hitpoints: " + hitpoints);
        ContactPoint2D hit = collision.GetContact(hitpoints - 1);
        //Debug.Log("--- HIT: " + hit.collider.name);
        if (!hit.Equals(null))
        {
            //if (hit.collider.name == "Player")
            {
                float collide_y = hit.collider.transform.position.y;
                float collide_x = hit.collider.transform.position.x;
                float contact_y_diff = (collide_y - this.transform.position.y);
                float contact_x_diff = (collide_x - this.transform.position.x);


                Debug.Log("Contact successful -- Contact point: " + collide_x + " - " + this.name + " position: " + this.transform.position.x);
                if (up && contact_y_diff < 0 && System.Math.Abs(contact_y_diff) > 0.21 && System.Math.Abs(contact_y_diff) < 0.24)
                {
                    Debug.Log("-----------Contact from below");
                    body.constraints = RigidbodyConstraints2D.None;
                    body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
                else if (down && contact_y_diff > 0 && System.Math.Abs(contact_y_diff) > 0.71 && System.Math.Abs(contact_y_diff) < 0.74)
                {
                    Debug.Log("-----------Contact from above");
                    body.constraints = RigidbodyConstraints2D.None;
                    body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
                else if (left && contact_x_diff > 0 && System.Math.Abs(contact_x_diff) > 0.70 && System.Math.Abs(contact_x_diff) < 0.74)
                {
                    Debug.Log("-----------Contact from the right");
                    body.constraints = RigidbodyConstraints2D.None;
                    body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }
                else if (right && contact_x_diff < 0 && System.Math.Abs(contact_x_diff) > 0.20 && System.Math.Abs(contact_x_diff) < 0.24)
                {
                    Debug.Log("-----------Contact from the left");
                    body.constraints = RigidbodyConstraints2D.None;
                    body.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    body.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }
    }

}
