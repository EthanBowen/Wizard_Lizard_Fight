﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
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
            air = true;
        }
        if (inputs.button_lower_stop)
        {
            air = false;
        }

        // Earth spell controller
        if (inputs.button_up)
        {
            earth = true;
        }
        if (inputs.button_up_stop)
        {
            earth = false;
            //StopEarth();
        }

        // Fire spell controller
        if (inputs.button_right)
        {
            fire = true;
        }
        if (inputs.button_right_stop)
        {
            fire = false;
        }

        // Water spell controller
        if (inputs.button_left)
        {
            water = true;
        }
        if(inputs.button_left_stop)
        {
            water = false;
        }


        Timer_BombDrop += Time.deltaTime;
    }

    // The delay before another bomb can be placed. Temporary.
    private float Timer_BombDrop = 0.0f;


    private void FixedUpdate()
    {
        if(fire)
        {
            if(!redMag.isPlaying)
            {
                redMag.Play();
            }
        }
        else
        {
            if (redMag.isPlaying)
            {
                redMag.Pause();
                redMag.Clear();
            }
        }

        if (water)
        {
            if (!blueMag.isPlaying)
            {
                blueMag.Play();
            }
        }
        else
        {
            if (blueMag.isPlaying)
            {
                blueMag.Pause();
                blueMag.Clear();
            }
        }

        if (air)
        {
            if (!whiteMag.isPlaying)
            {
                whiteMag.Play();
            }
        }
        else
        {
            if (whiteMag.isPlaying)
            {
                whiteMag.Pause();
                whiteMag.Clear();
            }
        }

        if (earth)
        {
            if (!greenMag.isPlaying)
            {
                greenMag.Play();
            }
        }
        else
        {
            if (greenMag.isPlaying)
            {
                greenMag.Pause();
                greenMag.Clear();
            }
        }

        // FIRE
        if (fire && !water)
        {
            if (!air && !earth)
            {
                MP -= 1;
                if (!fireSpell.isPlaying)
                {
                    StartFire();
                }
            }
            // BOMB
            else if (earth && !air && Timer_BombDrop > 0.5f)
            {
                if (MP >= 40)
                {
                    if (Timer_BombDrop > 0.5f)
                    {
                        earth = false;
                        fire = false;

                        Timer_BombDrop = 0.0f;
                        PlaceBomb();
                    }
                }
            }
            // FIRE TRAIL
            else if (air && !earth)
            {
                MP -= 4;
                if (!fireTrailSpell.isPlaying)
                {
                    StopAir();
                    StopFire();
                    StartFireTrail();
                }
            }
        }
        else
        {
            if (fireSpell.isPlaying)
            {
                StopFire();
            }
            if (fireTrailSpell.isPlaying)
            {
                StopFireTrail();
            }
        }
        // WATER
        if (water && !fire)
        {
            if (!air && !earth)
            {
                if (!blueMag.isPlaying)
                {
                    StartWater();
                }
            }
            // HEAL
            else if (earth && !air)
            {

            }
            else if (air && !earth)
            {

            }
        }
        // AIR
        if (air && !earth)
        {
            if (!fire && !water)
            {
                MP -= 1;
                if (!airSpell.isPlaying)
                {
                    StartAir();
                }
            }
        }
        else
        {
            if (airSpell.isPlaying)
            {
                StopAir();
            }
        }
        // EARTH
        if (earth && !air)
        {
            if (!fire && !water) // If an earth structure was already placed
            {
                StartEarth();
            }
        }


        if(!fire && !air && MP < maxMP)
        {
            MP += 1;
        }
        if(MP > maxMP)
        {
            MP = maxMP;
        }

        if(MP <= 0)
        {
            fire = false;
            water = false;
            air = false;
            earth = false;
        }
    }

    public void MovePlayer()//float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("Walking", true);

        }
        else
        {
            anim.SetBool("Walking", false);
            airSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
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

        if (airSpell.isEmitting)
        {
            pos.x *= 2;
            pos.y *= 2;
        }
        if (fireTrailSpell.isEmitting)
        {
            pos.x *= 4;
            pos.y *= 4;
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
            aimPos = SetRotationTo;
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

    //***********************************************************Air************************************************************
    public void StartAir()
    {
        airSpell.Play();
    }
     public void StopAir()
    {
        airSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    //***********************************************************Fire************************************************************
    public void StartFire()
    {
        fireSpell.Play();
        fireSpell.GetComponent<PolygonCollider2D>().enabled = true;

    }
    public void StopFire()
    {
        fireSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        fireSpell.GetComponent<PolygonCollider2D>().enabled = false;
    }

    //***********************************************************Water************************************************************
    public void StartWater()
    {

    }
    public void StopWater()
    {

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

        //earth = true;


    }
    public void StopEarth()
    {
        //earth = false;

    }

    //********************************************************Fire/Earth**********************************************************

    private GameObject HasPlacedBomb = null;
    private Quaternion aimPos;

    private void PlaceBomb()
    {
        if (HasPlacedBomb == null)
        {
            MP -= 30.0f;
            
            Vector3 positionOfBomb = new Vector3(2.0f, 0);

            positionOfBomb = aimPos * positionOfBomb;
            positionOfBomb += transform.position;

            GameObject bomb = Instantiate(attack_bomb, positionOfBomb, aimPos);

            _script_Bomb bombscript = bomb.GetComponent<_script_Bomb>();
            bombscript.SetPlayerID(ID);
            bombscript.ExplodeManually = true;
            bombscript.SetOwner(this);
            HasPlacedBomb = bomb;
        }
        else
        {
            _script_Bomb bombscript = HasPlacedBomb.GetComponent<_script_Bomb>();
            bombscript.Detonate();
            HasPlacedBomb = null;
        }
    }

    //********************************************************Fire/Air**********************************************************
    public void StartFireTrail()
    {
        // TODO: Aim trail behind player using CalcAimVector
        fireTrailSpell.Play();

    }
    public void StopFireTrail()
    {
        fireTrailSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }



    private void OnParticleCollision(GameObject other)
    {
        if (!dead)
        {
            // If the collision object doesn't have a PlayerAttack component, ignore it.
            if (other.GetComponent<PlayerAttack>() != null && ID != other.GetComponent<PlayerAttack>().PlayerID)
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
            // If the collision object doesn't have a PlayerAttack component, ignore it.
            if (collision.gameObject.GetComponent<PlayerAttack>() != null && ID != collision.gameObject.GetComponent<PlayerAttack>().PlayerID)
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dead)
        {
            GameObject collided = collision.gameObject;
            // Damage zone handling
            _script_KnockbackTrigger damagezone = collided.GetComponent<_script_KnockbackTrigger>();
            if (damagezone != null && damagezone.owner.ID != ID)
            {
                health -= damagezone.Damage;
                healthupdate.Invoke(ID, health);

                // Currently, knockback isn't cooperating with me.
                /*
                Vector2 difference = transform.position - damagezone.transform.position;
                difference = difference.normalized * damagezone.Knockback * 100;
                Debug.Log("Applying knockback to player: " + ID + " with vector: " + difference);
                gameObject.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
                */

                if (health <= 0)
                {
                    damagezone.ReportPoint();
                    Die();
                }
            }
            // For handling trigger zones that use the PlayerAttack module.
            PlayerAttack attack = collision.gameObject.GetComponent<PlayerAttack>();
            if (attack != null && attack.PlayerID != ID)
            {
                // Handles being hit by another player's attack zone.
            }
        }
    }


    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!dead)
        {
            GameObject collided = collision.gameObject;
            // Damage zone handling
            _script_DamageZone damagezone = collision.GetComponent<_script_DamageZone>();
            if (damagezone != null && damagezone.PlayerID != ID)
            {
                health -= damagezone.DamagePerCheck;
                healthupdate.Invoke(ID, health);

                if (health <= 0)
                {
                    damagezone.ReportPoint();
                    Die();
                }
            }
            // For handling trigger zones that use the PlayerAttack module.
            PlayerAttack attack = collision.gameObject.GetComponent<PlayerAttack>();
            if (attack != null && attack.PlayerID != ID)
            {
                // Handles being hit by another player's attack zone.
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

    // TODO: Clean these up
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
