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

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void MovePlayer(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if(horizontal > 0)
        {
            sprite.flipX = false;
        }
        else if(horizontal < 0)
        {
            sprite.flipX = true;
        }

        Vector2 pos = this.gameObject.transform.position;
        if (vertical != 0 && horizontal != 0)
        {
            pos.x += 0.70710678f * movementSpeed * Mathf.Sign(horizontal);
            pos.y += 0.70710678f * movementSpeed * Mathf.Sign(vertical);
        }
        else
        {
            if (vertical != 0)
            {
                pos.y += movementSpeed * Mathf.Sign(vertical);
            }

            if (horizontal != 0)
            {
                pos.x += movementSpeed * Mathf.Sign(horizontal);
            }
        }

        this.gameObject.transform.position = pos;
        
        return;
    }

    public void Aim(float horizontal, float vertical)
    {
        
    }

    public void CastMagic(bool wind, bool fire, bool water, bool earth)
    {
        if(wind)
        {
            WhiteMag.Play();
        }
        else
        {
            WhiteMag.Pause();
            WhiteMag.Clear();
        }
        if (fire)
        {
            RedMag.Play();
        }
        else
        {
            RedMag.Pause();
            RedMag.Clear();
        }
        if (water)
        {
            BlueMag.Play();
        }
        else
        {
            BlueMag.Pause();
            BlueMag.Clear();
        }
        if (earth)
        {
            GreenMag.Play();
        }
        else
        {
            GreenMag.Pause();
            GreenMag.Clear();
        }


    }

    /*
     * Called when the lower face button "A" button is pressed.
     */
    public void StartWind()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"A\" pressed");
        WhiteMag.Play();
    }
     public void StopWind()
    {
        WhiteMag.Pause();
        WhiteMag.Clear();
    }

    public void StartFire()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"B\" pressed");
        RedMag.Play();
        FireSpell.Play();
    }
    public void StopFire()
    {
        RedMag.Pause();
        RedMag.Clear();
        FireSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!dead)
        {
            //other.get
            if (other.tag.Equals("Fire"))
            {
                health -= fireDamage;
            }

            if (health <= 0)
            {
                dead = true;
                other.GetComponent<PlayerAttack>().ReportPoint();
                this.gameObject.SetActive(false);
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                Invoke("Respawn", 5);
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
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
