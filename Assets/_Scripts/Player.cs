using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 1000;
    public int fireDamage = 4;
    public int waterDamage = 40;
    private int playerNum = 0;

    private int health;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    }

    private void OnParticleCollision(GameObject other)
    {
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
        switch(playerNum) 
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
