using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    // Variables for player movement
    public float movementSpeed = 5f;
    public float diagonalMoveSpeedMultiplier = 1f;

    // Variables for player info
    public float maxHealth = 1000;
    public float maxMP = 100;
    public int fireDamage = 4;
    public int waterDamage = 40;
    public int score = 0;
    private bool dead;

    public float horizontal = 0, vertical = 0;
    private Rigidbody2D body;

    private bool fire, wind, water, earth;

    public int ID = 0;

    public float health;
    public float MP;
    public Vector3 SpawnPoint;

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

    public GameObject healthBar;
    public GameObject manaBar;
    private Event_PlayerHealthChanged healthupdate;

    public GameObject attack_bomb;

    // The player reads only their own inputs from this class. 
    public _script_ReadInputs inputs;


    private void Awake()
    {
        healthBar.GetComponent<HealthBar>().PlayerMaxHealth = maxHealth;
        manaBar.GetComponent<ManaBar>().PlayerMaxMana = maxMP;
        Initialization_SetUpEventSystemFor_ThisPlayersHealthUpdates();
    }

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        //gameObject.GetComponent<SpriteRenderer>().
        score = 0;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.ReadPlayerInputs();
        
        horizontal = inputs.PLAYER_horiz_move;
        vertical = inputs.PLAYER_vert_move;
        MovePlayer();// PLAYER_horiz_move, PLAYER_vert_move);
        if (inputs.button_lower)
        {
            StartWind();
        }
        if (inputs.button_lower_stop)
        {
            StopWind();
        }
        if (inputs.button_right)
        {
            StartFire();
        }
        if (inputs.button_right_stop)
        {
            StopFire();
        }
        if (inputs.button_left)
        {
            // Cannot place bombs back-to-back. There's a delay.
            if (Timer_BombDrop > 4.0f)
            {
                Timer_BombDrop = 0.0f;
                PlaceBomb();
            }
        }


        Timer_BombDrop += Time.deltaTime;
    }

    // The delay before another bomb can be placed. Temporary.
    private float Timer_BombDrop = 0.0f;

    private void FixedUpdate()
    {
        if(fire)
        {
            MP -= 1;
        }
        if (wind)
        {
            MP -= 1;
        }

        if(!fire && !wind && MP < maxMP)
        {
            MP += 5;
        }
        if(MP > maxMP)
        {
            MP = maxMP;
        }

        if(MP <= 0)
        {
            StopFire();
            StopWind();
        }
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
                    healthupdate.Invoke(ID, health);
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
        MP = maxMP;
        healthupdate.Invoke(ID, health);
        /*switch(ID) 
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

        }*/
        this.gameObject.transform.position = SpawnPoint;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        this.gameObject.SetActive(true);
        dead = false;
    }


    private void PlaceBomb()
    {
        MP -= 30.0f;
        GameObject bomb = Instantiate(attack_bomb);
        bomb.transform.position = new Vector3(transform.position.x + 2.0f, transform.position.y + 2.0f, this.transform.position.z);
        //bomb.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        _script_Bomb bombscript = bomb.GetComponent<_script_Bomb>();
        bombscript.SetPlayerID(ID);
    }



    /**
     * Note from Alex ---
     * 
     * This is called on Awake() so that when the player's health changes, any listener (like the health bar)
     * will receive an update about it.
     */
    private void Initialization_SetUpEventSystemFor_ThisPlayersHealthUpdates()
    {
        if (healthupdate == null)
        {
            healthupdate = new Event_PlayerHealthChanged();
        }

        healthupdate.AddListener(healthBar.GetComponent<HealthBar>().event_player_healthchanged);
    }


    /**
     * Note from Alex ---
     * 
     * This is holdover from moving input management to an event based system. While it works, I think
     * the move to having the individual player object control their own inputs is simply better.
     * 
     * Leaving this in as a representation of how to handle events. Look to _class_WizardLizardEvents to
     * add more events. The location that calls the event (like GameController) must also do stuff to
     * actually call those events. Look there for a bit of a guide.
     */
    public void event_input_Wind(bool buttondown)
    {
        Debug.Log("Player " + ID + " detected Wind button input event: " + buttondown);
    }


}
