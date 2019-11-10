
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerBackup : MonoBehaviour
{
    // Variables for player movement
    public float movementSpeed = 10f;
    public float diagonalMoveSpeedMultiplier = 1f;

    // Variables for player info
    public float maxHealth = 100;
    public float maxMP = 100;
    //public int fireDamage = 4;
    //public int waterDamage = 40;
    public int score = 0;
    private bool dead;

    public float horizontal = 0, vertical = 0;
    private Rigidbody2D body;

    private bool fire, air, water, earth;

    public int ID = 0;

    public float health;
    public float MP;
    public Vector3 SpawnPoint;

    private GameController gameController;



    // Controls animations
    private SpriteRenderer sprite;
    private Animator anim;
    public ParticleSystem redMag;
    public ParticleSystem fireSpell;
    public ParticleSystem greenMag;
    public ParticleSystem blueMag;
    //public ParticleSystem WaterSpell;
    public ParticleSystem whiteMag;
    public ParticleSystem airSpell;

    public ParticleSystem fireTrailSpell;

    public GameObject healthBar;
    public GameObject manaBar;
    private Event_PlayerHealthChanged healthupdate;

    public GameObject attack_bomb;
    public GameObject waterSpell;

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

        // The air spell controller
        if (inputs.button_lower)
        {
            if (!fire && !water && !earth)
            {
                StartAir();
            }
            else if (fire)
            {
                StopFire();
                StartFireTrail();
            }
        }
        if (inputs.button_lower_stop)
        {
            StopAir();
            StopFireTrail();
        }

        // Earth spell controller
        if (inputs.button_up)
        {
            if (earth && !fire && !water && !air) // If an earth structure was already placed
            {
                StartEarth();
            }
            if (fire && Timer_BombDrop > 4.0f)
            {
                StopFire();
                if (Timer_BombDrop > 4.0f)
                {
                    Timer_BombDrop = 0.0f;
                    PlaceBomb();
                }
            }
        }
        if (inputs.button_up_stop)
        {
            StopEarth();
        }

        // Fire spell controller
        if (inputs.button_right)
        {
            if (!air && !earth && !water)
            {
                StartFire();
            }
            else if (earth && Timer_BombDrop > 4.0f)
            {
                StopEarth();
                if (Timer_BombDrop > 4.0f)
                {
                    Timer_BombDrop = 0.0f;
                    PlaceBomb();
                }
            }
            else if (air)
            {
                StopAir();
                StartFireTrail();
            }
        }
        if (inputs.button_right_stop)
        {
            StopFire();
            StopFireTrail();
        }

        // Water spell controller
        if (inputs.button_left)
        {
            if (!air && !earth && !fire)
            {
                StartWater();
            }
            else if (earth)
            {

            }
        }
        if (inputs.button_left_stop)
        {
            StopWater();
        }


        Timer_BombDrop += Time.deltaTime;
    }

    // The delay before another bomb can be placed. Temporary.
    private float Timer_BombDrop = 0.0f;

    private void FixedUpdate()
    {
        if (fire)
        {
            MP -= 1;
        }
        if (air)
        {
            MP -= 1;
            //if
        }

        if (!fire && !air && MP < maxMP)
        {
            MP += 1;
        }
        if (MP > maxMP)
        {
            MP = maxMP;
        }

        if (MP <= 0)
        {
            StopFire();
            StopAir();
            StopEarth();
            StopWater();
            StopFireTrail();
        }
    }

    public void MovePlayer()//float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("Walking", true);
            //if(air && !airSpell.isPlaying)
            //{
            //    
            //}
        }
        else
        {
            anim.SetBool("Walking", false);
            airSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        if (horizontal > 0)
        {
            sprite.flipX = false;
        }
        else if (horizontal < 0)
        {
            sprite.flipX = true;
        }

        Vector2 pos = new Vector2();
        if (horizontal != 0)
            pos.x = movementSpeed * (horizontal / Mathf.Sqrt(horizontal * horizontal + vertical * vertical));
        else
        {
            pos.x = 0;
        }
        if (vertical != 0)
            pos.y = movementSpeed * (vertical / Mathf.Sqrt(horizontal * horizontal + vertical * vertical));
        else
            pos.y = 0;

        if (air)
        {
            pos.x *= 2;
            pos.y *= 2;
        }

        body.velocity = pos;

        Aim();

        return;
    }

    public void Aim()
    {
        // Only aim when there's a potential new direction to aim at.
        if (horizontal != 0 || vertical != 0)
        {
            Quaternion SetRotationTo = CalcAimVector(horizontal, vertical);
            fireSpell.transform.rotation = SetRotationTo;
            airSpell.transform.rotation = SetRotationTo;

        }
    }


    private Quaternion CalcAimVector(float x_in, float y_in)
    {
        float angle = Mathf.Atan2(y_in, x_in) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return Quaternion.Lerp(fireSpell.transform.rotation, rotation, 1.0f);
    }

    //*********************************************************************************************************************************************************************
    //********************************************************         Spells         *************************************************************************************
    //*********************************************************************************************************************************************************************

    //***********************************************************air************************************************************
    public void StartAir()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"A\" pressed");
        air = true;
        //movementSpeed *= 5;
        whiteMag.Play();
        airSpell.Play();
    }
    public void StopAir()
    {
        //air = false;
        //movementSpeed /= 5;
        whiteMag.Pause();
        whiteMag.Clear();
        airSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    //***********************************************************Fire************************************************************
    public void StartFire()
    {
        //Debug.Log("-[PLAYER " + ID + "] Button \"B\" pressed");

        fire = true;
        redMag.Play();
        fireSpell.Play();
        fireSpell.GetComponent<PolygonCollider2D>().enabled = true;

    }
    public void StopFire()
    {
        fire = false;

        redMag.Pause();
        redMag.Clear();
        fireSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        fireSpell.GetComponent<PolygonCollider2D>().enabled = false;
    }

    //***********************************************************Water************************************************************
    public void StartWater()
    {
        water = true;
        blueMag.Play();
       //WaterSpell.Play();
        //WaterSpell.GetComponent<PolygonCollider2D>().enabled = true;

    }
    public void StopWater()
    {
        water = false;

        blueMag.Pause();
        blueMag.Clear();
        //WaterSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //WaterSpell.GetComponent<PolygonCollider2D>().enabled = false;
    }
    public void CastWater()
    {
        MP -= 30.0f;
        Quaternion aimPos = CalcAimVector(horizontal, vertical);

        Vector3 positionOfWater = new Vector3(2.0f, 0);

        positionOfWater = aimPos * positionOfWater;
        positionOfWater += transform.position;

        GameObject water = Instantiate(attack_bomb, positionOfWater, aimPos);

        PlayerAttack pa = water.GetComponent<PlayerAttack>();
        pa.AssignID(ID);

    }

    //***********************************************************Earth************************************************************
    public void StartEarth()
    {
        Debug.Log("-[PLAYER " + ID + "] Button \"B\" pressed");

        earth = true;
        greenMag.Play();

    }
    public void StopEarth()
    {
        earth = false;

        greenMag.Pause();
        greenMag.Clear();
    }

    //********************************************************Fire/Earth**********************************************************
    private void PlaceBomb()
    {
        MP -= 30.0f;
        Quaternion aimPos = CalcAimVector(horizontal, vertical);

        Vector3 positionOfBomb = new Vector3(2.0f, 0);

        positionOfBomb = aimPos * positionOfBomb;
        positionOfBomb += transform.position;

        GameObject bomb = Instantiate(attack_bomb, positionOfBomb, aimPos);

        _script_Bomb bombscript = bomb.GetComponent<_script_Bomb>();
        bombscript.SetPlayerID(ID);
    }

    //********************************************************Fire/air**********************************************************
    public void StartFireTrail()
    {
        fire = true;
        air = true;

        redMag.Play();
        whiteMag.Play();
        fireTrailSpell.Play();
        //FireSpell.GetComponent<PolygonCollider2D>().enabled = true;

    }
    public void StopFireTrail()
    {
        fire = false;
        air = false;

        redMag.Pause();
        redMag.Clear();
        whiteMag.Pause();
        whiteMag.Clear();
        fireTrailSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //FireTrailSpell.GetComponent<PolygonCollider2D>().enabled = false;
    }



    private void OnParticleCollision(GameObject other)
    {
        if (!dead)
        {
            if (ID != other.GetComponent<PlayerAttack>().PlayerID)
            {
                health -= other.GetComponent<PlayerAttack>().damage;
                healthupdate.Invoke(ID, health);

                if (health <= 0)
                {
                    other.GetComponent<PlayerAttack>().ReportPoint();
                    Die();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!dead)
        {
            if (ID != collision.gameObject.GetComponent<PlayerAttack>().PlayerID)
            {
                health -= collision.gameObject.GetComponent<PlayerAttack>().damage;
                healthupdate.Invoke(ID, health);

                if (health <= 0)
                {
                    collision.gameObject.GetComponent<PlayerAttack>().ReportPoint();
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
        fire = air = water = earth = false;

        this.gameObject.SetActive(false);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Invoke("Respawn", 5);
    }


    private void Respawn()
    {
        health = maxHealth;
        MP = maxMP;
        healthupdate.Invoke(ID, health);

        this.gameObject.transform.position = SpawnPoint;

        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        this.gameObject.SetActive(true);

        dead = false;
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
    public void event_input_air(bool buttondown)
    {
        Debug.Log("Player " + ID + " detected air button input event: " + buttondown);
    }


    public void Detectair(InputAction.CallbackContext context)
    {
        Debug.Log("Detected air on PLAYER: " + ID);
    }

    public void DetectMovement(InputAction.CallbackContext context)
    {
        Debug.Log("Detecting movement on player: " + ID);
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }


}
