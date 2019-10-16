using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables for player movement
    public float movementSpeed = 5f;
    public float diagonalMoveSpeedMultiplier = 1f;

    // Variables for player info
    public int maxHealth = 1000;
    public int fireDamage = 4;
    public int waterDamage = 40;
    public int score = 0;
    private bool dead;

    public float horizontal = 0, vertical = 0;
    private Rigidbody2D body;

    private bool fire, wind, water, earth;

    public int ID = 0;

    public int health;

    private GameController gameController;

    // Controls animations
    private SpriteRenderer sprite;
    private Animator anim;
    public ParticleSystem RedMag;
    public ParticleSystem FireSpell;
    public ParticleSystem GreenMag;
    public ParticleSystem BlueMag;
    public ParticleSystem WhiteMag;
    public ParticleSystem WindSpell;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        score = 0;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //FireSpell.gameObject.GetComponent<Collider2D>().enabled = fire;
    }

    public void MovePlayer()//float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("Walking", true);
            if(wind && !WindSpell.isPlaying)
            {
                WindSpell.Play();
            }
        }
        else
        {
            anim.SetBool("Walking", false);
            WindSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        if(horizontal > 0)
        {
            sprite.flipX = false;
        }
        else if(horizontal < 0)
        {
            sprite.flipX = true;
        }

        Vector2 pos = new Vector2();
        
        pos.x = movementSpeed * horizontal;
        pos.y = movementSpeed * vertical;

        if(wind)
        {
            pos.x *= 2;
            pos.y *= 2;
        }
       
        body.velocity = pos;//this.gameObject.transform.position = pos;

        Aim();

        return;
    }

    public void Aim()
    {
        FireSpell.transform.LookAt(new Vector2(transform.position.x + horizontal, transform.position.y + vertical));
        WindSpell.transform.LookAt(new Vector2(transform.position.x - horizontal, transform.position.y - vertical));
    }

    /*
     * Called when the lower face button "A" button is pressed.
     */
    public void StartWind()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"A\" pressed");
        wind = true;
        //movementSpeed *= 5;
        WhiteMag.Play();
    }
     public void StopWind()
    {
        wind = false;
        //movementSpeed /= 5;
        WhiteMag.Pause();
        WhiteMag.Clear();
        WindSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void StartFire()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"B\" pressed");
        
        fire = true;
        RedMag.Play();
        FireSpell.Play();
       
    }
    public void StopFire()
    {
        fire = false;
        
        RedMag.Pause();
        RedMag.Clear();
        FireSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!dead)
        {
            if (ID != other.GetComponent<PlayerAttack>().PlayerID)
            {
                //other.get
                if (other.tag.Equals("Fire"))
                {
                    health -= fireDamage;
                }

                if (health <= 0)
                {
                    other.GetComponent<PlayerAttack>().ReportPoint();
                    Die();
                }
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!dead)
        {
            GameObject other = collision.gameObject;
            if (ID != other.GetComponent<PlayerAttack>().PlayerID)
            {
                //other.get
                if (other.tag.Equals("Fire"))
                {
                    health -= fireDamage;
                }

                if (health <= 0)
                {
                    other.GetComponent<PlayerAttack>().ReportPoint();
                    Die();
                }
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    private void Die()
    {
        dead = true;
        fire = wind = water = earth = false;
        
        this.gameObject.SetActive(false);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Invoke("Respawn", 5);
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
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        this.gameObject.SetActive(true);
        dead = false;
           
    }
}
