using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables for player movement
    public float MovementSpeed = 5f;
    public float DiagonalMoveSpeedMultiplier = 1f;

    // Variables for player info
    public int maxHealth = 1000;
    public int fireDamage = 4;
    public int waterDamage = 40;

    public int ID = 0;

    private int health;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    }

    public void MovePlayer(float horizontal, float vertical)
    {

        Vector2 pos = this.gameObject.transform.position;
        if (vertical != 0)
        {
            pos.y += MovementSpeed * Mathf.Sign(vertical);
        }
        //else
        //{
        //    pos.y = 0;
        //}
        if (horizontal != 0)
        {
            pos.x += MovementSpeed * Mathf.Sign(horizontal);
        }
        //else
        //{
        //    pos.x = 0;
        //}
        if (vertical != 0 && horizontal != 0)
        {
            //float average = Mathf.Sqrt(MovementSpeed);
            float average = Mathf.Sqrt(Mathf.Pow(horizontal, 2) + Mathf.Pow(vertical, 2));
            pos.x += average * MovementSpeed * Mathf.Sign(horizontal);
            pos.y += average * MovementSpeed * Mathf.Sign(vertical);
        }

        this.gameObject.transform.position = pos;
        return;
    }

    /*
     * Called when the lower face button "A" button is pressed.
     */
    public void button_lower()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"A\" pressed");
        return;
    }

    private void OnParticleCollision(GameObject other)
    {
        //other.get
        if (other.tag.Equals("Fire"))
        {
            health -= fireDamage;
        }

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            Invoke("Respawn", 5);
        }
    }

    private void Respawn()
    {
        health = maxHealth;
        switch(ID) 
        {
            case 2:
                this.gameObject.transform.position = new Vector3(10.0f, 10.0f);
                break;
            case 3:
                this.gameObject.transform.position = new Vector3(-10.0f, -10.0f);
                break;
            case 4:
                this.gameObject.transform.position = new Vector3(10.0f, -10.0f);
                break;
            default:
                this.gameObject.transform.position = new Vector3(-10.0f, 10.0f);
                break;

        }

        this.gameObject.SetActive(true);
           
    }
}
