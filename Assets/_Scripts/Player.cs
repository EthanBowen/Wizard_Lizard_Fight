
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
{
    // Variables for player movement
    [Header("Player Settings")]
    public float movementSpeed = 10f;
    public float diagonalMoveSpeedMultiplier = 1f;
    public float maxHealth = 100;
    public float maxMP = 100;
    private bool dead;

    [Header("Fire Settings")]
    public ParticleSystem fireSpell;
    public float FireManaCost = 4f;

    [Header("Watershot Settings")]
    public GameObject waterSpell;
    public float WaterShotSpeed = 1f;
    public float WaterShotChargeSpeed = 1f;
    public float WaterShotMaxCharge = 40f;
    public AudioSource waterShot;

    [Header("Wind Settings")]
    public ParticleSystem airSpell;
    public float AirStartManaCost = 10.0f;
    public float AirSustainManaCost = 4f;
    public AudioSource airDash;

    [Header("Rockwall Settings")]
    public GameObject RockWall;
    public float RockWallManaCost = 40.0f;
    public float RockWallSize = 1f;
    public float RockWallPlaceDistance = 2f;
    public AudioSource rockBuild;

    [Header("Bomb Settings")]
    public GameObject attack_bomb;
    public float BombManaCost = 40.0f;
    public float BombDamage = 100f;
    public float BombRadius = 2f;
    public float FireDamagePerCheck = 1f;
    public AudioSource bombPlace;

    [Header("Iceshot Settings")]
    public GameObject iceSpell;
    public float IceShotSpeed = 0.5f;
    public float IceShotChargeSpeed = 1f;
    public float IceShotMinCharge = 20f;
    public float IceShotMaxCharge = 40f;
    public AudioSource iceShot;

    [Header("Firetrail Settings")]
    public ParticleSystem fireTrailSpell;
    public float FireTrailStartManaCost = 10.0f;
    public float FireTrailSustainManaCost = 4f;
    public AudioSource fireDash;

    [Header("Heal Settings")]
    public ParticleSystem healSpell;
    public float HealPerMana = 0.5f;
    public float HealCost = 1f;
    public AudioSource healing;

    private Rigidbody2D body;

    private bool fire, air, water, earth;
    private bool fireActive = false, airActive = false, fireTrailActive = false, healActive = false;

    [Header("Gameplay Information")]
    public int ID = 0;
    public int score = 0;
    public int numTowers = 0;
    public float damageDone = 0;
    public float damageTaken = 0;
    public float health;
    public float MP;
    public Vector3 SpawnPoint;
    public float horizontal = 0, vertical = 0;

    private GameController gameController;

    // Controls animations
    [Header("Animation Data")]
    public SpriteRenderer sprite;
    public Animator anim;
    public ParticleSystem redMag;
    public ParticleSystem greenMag;
    public ParticleSystem blueMag;
    public ParticleSystem whiteMag;
    public GameObject wand;

    [Header("UI")]
    public GameObject healthBar;
    public GameObject manaBar;
    private Event_PlayerHealthChanged healthupdate;

    // The player reads only their own inputs from this class. 
    public _script_ReadInputs inputs;

    public RuntimeAnimatorController[] characterList;


    private void Awake()
    {
        healthBar.GetComponent<HealthBar>().PlayerMaxHealth = maxHealth;
        manaBar.GetComponent<ManaBar>().PlayerMaxMana = maxMP;
        Initialization_SetUpEventSystemFor_ThisPlayersHealthUpdates();
    }

    // Start is called before the first frame update
    void Start()
    {
        airDash.Stop();
        fireDash.Stop();
        healing.Stop();
        body = gameObject.GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        //gameObject.GetComponent<SpriteRenderer>().
        score = 0;
        selectCharacter();
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.ReadPlayerInputs();
        
        horizontal = inputs.PLAYER_horiz_move;
        vertical = inputs.PLAYER_vert_move;
        MovePlayer();

        // The air spell controller
        if (inputs.button_lower)
        {
            air = true;
            wand.GetComponent<Animator>().SetBool("Casting", true);
        }
        if (inputs.button_lower_stop)
        {
            air = false;
        }

        // Earth spell controller
        if (inputs.button_up)
        {
            earth = true;
            wand.GetComponent<Animator>().SetBool("Casting", true);
        }
        if (inputs.button_up_stop)
        {
            earth = false;
        }

        // Fire spell controller
        if (inputs.button_right)
        {
            fire = true;
            wand.GetComponent<Animator>().SetBool("Casting", true);
        }
        if (inputs.button_right_stop)
        {
            fire = false;
        }

        // Water spell controller
        if (inputs.button_left)
        {
            water = true;
            wand.GetComponent<Animator>().SetBool("Casting", true);
        }
        if(inputs.button_left_stop)
        {
            water = false;
        }


        Timer_BombDrop += Time.deltaTime;
    }

    // The delay before another bomb can be placed. Temporary.
    private float Timer_BombDrop = 0.0f;

    private float chargeWaterSpell = 0.0f;
    private float chargeIceSpell = 0.0f;
    private bool earthReady = false;


    private void FixedUpdate()
    {
        if(fire)
        {
            if(!redMag.isPlaying)
            {
                redMag.Play();
                wand.GetComponent<Animator>().SetBool("Casting", true);
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
                wand.GetComponent<Animator>().SetBool("Casting", true);
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
                wand.GetComponent<Animator>().SetBool("Casting", true);
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
                wand.GetComponent<Animator>().SetBool("Casting", true);
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

        if (!earth && earthReady)
        {
            CastEarth();
            earthReady = false;
        }

        // FIRE
        if (fire && !water)
        {
            if (!air && !earth)
            {
                if (!fireActive)
                {
                    StartFire();
                }
            }
            // BOMB
            else if (earth && !air && Timer_BombDrop > 0.5f)
            {
                if (MP >= BombManaCost)
                {
                    if (Timer_BombDrop > 0.5f)
                    {
                        earth = false;
                        fire = false;
                        earthReady = false;

                        Timer_BombDrop = 0.0f;
                        PlaceBomb();
                    }
                }
            }
            // FIRE TRAIL
            else if (air && !earth)
            {
                if (airActive || fireActive)
                {
                    StopAir();
                    StopFire();
                    
                }
            }
        }
        else
        {
            if (fireActive)
            {
                StopFire();
            }
            if (fireTrailActive)
            {
                StopFireTrail();
            }
        }
        // WATER
        if (water && !fire)
        {
            if (!air && !earth && !healActive)
            {
                if (chargeWaterSpell < WaterShotMaxCharge)
                {
                    chargeWaterSpell += WaterShotChargeSpeed;
                }
            }
            // HEAL
            else if (earth && !air)
            {
                chargeWaterSpell = 0.0f;
                if (!healActive)
                {
                    earthReady = false;
                    StartHeal();
                }
            }
            // ICE
            else if (air && !earth)
            {
                chargeWaterSpell = 0.0f;
                if (chargeIceSpell < IceShotMaxCharge)
                {
                    chargeIceSpell += IceShotChargeSpeed;
                }
            }
           
        }
        else
        {
            if(!healActive)
            {
                CastWater();
            }
        }
        // AIR
        if (air && !earth)
        {
            if (!fire && !water)
            {
                // Do nothing
            }
        }
        else
        {
            if (airActive)
            {
                StopAir();
            }
            if (fireTrailActive)
            {
                StopFireTrail();
            }
        }
        // EARTH
        if (earth && !air)
        {
            if (!fire && !water) // If an earth structure was already placed
            {
                earthReady = true; 
            }
        }

        if(!water || !air)
        {
            CastIce();
        }

        if (!water || !earth)
        {
            if (healActive)
            {
                StopHeal();
            }
        }

        bool spellActive = fireActive || airActive || fireTrailActive || (healActive && health < maxHealth);
        if (!spellActive && MP < maxMP)
        {
            MP += 1;
        }
        else if (fireActive)
        {
            MP -= FireManaCost;
        }
        else if (airActive)
        {
            MP -= AirSustainManaCost;
        }
        else if (fireTrailActive)
        {
            MP -= FireTrailSustainManaCost;
        }
        else if (healActive && health < maxHealth)
        {
            MP -= HealCost;
            health += HealPerMana;
        }

        if(!fire && !water && !air && !earth)
        {
            wand.GetComponent<Animator>().SetBool("Casting", false);
        }

        if (MP > maxMP)
        {
            MP = maxMP;
        }
        
        if (MP <= 0)
        {
            MP = 0.0f;
            anim.SetBool("Casting", false);
            wand.GetComponent<Animator>().SetBool("Casting", false);
            fire = false;
            water = false;
            air = false;
            earth = false;
        }
    }

    public void MovePlayer()
    {
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("Walking", true);
            if(fire && air && !fireTrailActive
                && !water && !earth)
            {
                StartFireTrail();
            }
            else if (air && !fire && !airActive
                && !water && !earth)
            {
                StartAir();
            }

            if (fireTrailActive && water || earth)
            {
                StopFireTrail();
            }
            if (airActive && fire || water || earth)
            {
                StopAir();
            }

        }
        else
        {
            anim.SetBool("Walking", false);
            if (airActive)
            {
                StopAir();
            }
            if (fireTrailActive)
            {
                StopFireTrail();
            }
            
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

        if (airActive)
        {
            //MP -= 1;
            pos.x *= 2;
            pos.y *= 2;
        }
        if (fireTrailActive)
        {
            //MP -= 4;
            pos.x *= 4;
            pos.y *= 4;
        }

        body.velocity = pos;

        Aim();

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)(gameObject.transform.position.y * 10);
        wand.GetComponent<SpriteRenderer>().sortingOrder = 1 - (int)(gameObject.transform.position.y * 10);

        return;
    }

    public void Aim()
    {
        // Only aim when there's a potential new direction to aim at.
        if (horizontal != 0 || vertical != 0)
        {
            Quaternion SetRotationTo = CalcAimVector(horizontal, vertical);
            //fireSpell.transform.rotation = SetRotationTo;
            airSpell.transform.rotation = SetRotationTo;
            wand.transform.rotation = SetRotationTo;
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
        if (MP >= AirStartManaCost)
        {
            MP -= AirStartManaCost;
            airSpell.Play();
            anim.SetBool("Casting", true);
            airActive = true;
            airDash.Play();
        }
    }
    public void StopAir()
    {
        airDash.Stop();
        airSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        anim.SetBool("Casting", false);
        airActive = false;
    }

    //***********************************************************Fire************************************************************
    public void StartFire()
    {
        fireSpell.Play();
        anim.SetBool("Casting", true);
        //fireSpell.GetComponent<PolygonCollider2D>().enabled = true;
        fireActive = true;
    }
    public void StopFire()
    {
        fireSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        anim.SetBool("Casting", false);
        // fireSpell.GetComponent<PolygonCollider2D>().enabled = false;
        fireActive = false;
    }

    //***********************************************************Water************************************************************
    public void CastWater()
    {
        if (chargeWaterSpell > 0 && MP >= chargeWaterSpell)
        {
            MP -= chargeWaterSpell;
            anim.SetBool("Casting", true);

            //Quaternion aimPos = CalcAimVector(horizontal, vertical);

            Vector3 positionOfWater = new Vector3(2.0f, 0);

            positionOfWater = fireSpell.transform.position;//aimPos * positionOfWater;
                                                           //positionOfWater += transform.position;

            GameObject water = Instantiate(waterSpell, positionOfWater, aimPos);

            Vector2 difference = water.transform.position - wand.transform.position;
            difference = difference.normalized * WaterShotSpeed * 10;

            water.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Force);

            //water.GetComponent<WaterSpell>().x = positionOfWater.x;
            //water.GetComponent<WaterSpell>().y = positionOfWater.y;

            PlayerAttack pa = water.GetComponent<PlayerAttack>();
            pa.SetOwner(this);
            pa.AssignID(ID);
            pa.damage = chargeWaterSpell;

            waterShot.Play();
            //water.SetActive(true);
            anim.SetBool("Casting", false);

        }

        chargeWaterSpell = 0.0f;
    }

    //***********************************************************Earth************************************************************

    private GameObject placedRockWall = null;

    public void CastEarth()
    {
        if (MP >= RockWallManaCost)
        {
            if (placedRockWall != null)
            {
                GameObject.Destroy(placedRockWall);
                placedRockWall = null;
            }

            MP -= RockWallManaCost;

            Vector3 positionOfWall = new Vector3(RockWallPlaceDistance, 0);

            positionOfWall = aimPos * positionOfWall;
            positionOfWall += wand.transform.position;

            GameObject wall = Instantiate(RockWall, positionOfWall, aimPos);
            rockBuild.Play();
            placedRockWall = wall;
        }
    }

    //********************************************************Fire/Air**********************************************************
    public void StartFireTrail()
    {
        if (MP >= FireTrailStartManaCost)
        {
            MP -= FireTrailStartManaCost;
            fireTrailSpell.Play();
            anim.SetBool("Casting", true);
            fireTrailActive = true;
            fireDash.Play();
        }
    }
    public void StopFireTrail()
    {
        fireDash.Stop();
        fireTrailSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        anim.SetBool("Casting", false);
        fireTrailActive = false;
    }

    //********************************************************Fire/Earth**********************************************************

    private GameObject HasPlacedBomb = null;
    private Quaternion aimPos;

    private void PlaceBomb()
    {
        if (MP >= BombManaCost)
        {
            if (HasPlacedBomb == null)
            {
                MP -= BombManaCost;

                Vector3 positionOfBomb = new Vector3(2.0f, 0);

                positionOfBomb = aimPos * positionOfBomb;
                positionOfBomb += wand.transform.position;

                GameObject bomb = Instantiate(attack_bomb, positionOfBomb, aimPos);

                PlayerAttack pa = bomb.GetComponent<PlayerAttack>();
                pa.SetOwner(this);
                pa.AssignID(ID);

                _script_Bomb bombscript = bomb.GetComponent<_script_Bomb>();
                bombscript.SetPlayerID(ID);
                bombscript.ExplodeManually = true;
                bombscript.ExplosionDamage = BombDamage;
                bombscript.ExplosionRadius = BombRadius;
                bombscript.FireDamagePerCheck = FireDamagePerCheck;
                bombscript.SetOwner(this);
                HasPlacedBomb = bomb;
                bombPlace.Play();
            }
            else
            {
                _script_Bomb bombscript = HasPlacedBomb.GetComponent<_script_Bomb>();
                bombscript.Detonate();
                HasPlacedBomb = null;
            }
        }
    }

    //*******************************************************Water/Air************************************************************
    public void CastIce()
    {
        if (chargeIceSpell >= IceShotMinCharge && MP >= chargeIceSpell * 2)
        {
            MP -= chargeIceSpell * 2;

            //Quaternion aimPos = CalcAimVector(horizontal, vertical);

            Vector3 positionOfIce = new Vector3(2.0f, 0);

            positionOfIce = fireSpell.transform.position;//aimPos * positionOfIce;
                                                         //positionOfIce += transform.position;

            GameObject ice = Instantiate(iceSpell, positionOfIce, aimPos);

            Vector2 difference = ice.transform.position - wand.transform.position;
            difference = difference.normalized * IceShotSpeed * 10;

            ice.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Force);

            PlayerAttack pa = ice.GetComponent<PlayerAttack>();
            pa.SetOwner(this);
            pa.AssignID(ID);
            pa.damage = chargeIceSpell;

            iceShot.Play();
            //water.SetActive(true);
        }

        chargeIceSpell = 0.0f;
    }

    //*******************************************************Water/Earth************************************************************
    public void StartHeal()
    {
        healSpell.Play();
        anim.SetBool("Casting", true);
        healActive = true;
        healing.Play();
    }
    public void StopHeal()
    {
        healSpell.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        anim.SetBool("Casting", false);
        healActive = false;
        healing.Stop();
    }

    //*********************************************************************************************************************************************************************
    //********************************************************      Hit Detection     *************************************************************************************
    //*********************************************************************************************************************************************************************

    private void OnParticleCollision(GameObject other)
    {
        if (!dead)
        {
            takeDamage(other);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!dead)
        {
            takeDamage(collision.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dead)
        {
            takeDamage(collision.gameObject);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!dead)
        {
            /*GameObject collided = collision.gameObject;
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
            }*/
            _script_DamageZone damagezone = collision.gameObject.GetComponent<_script_DamageZone>();
            if (damagezone != null)
            {
                takeDamage(collision.gameObject);
            }
        }
    }

    private void takeDamage(GameObject other)
    {
        // If the collision object doesn't have a PlayerAttack component, ignore it.
        PlayerAttack attack = other.GetComponent<PlayerAttack>();
        _script_DamageZone damagezone = other.GetComponent<_script_DamageZone>();
        
        if (damagezone != null && damagezone.PlayerID != ID)
        {
            if (health >= damagezone.DamagePerCheck)
            {
                damagezone.ReportDamage(damagezone.DamagePerCheck);
                damageTaken += damagezone.DamagePerCheck;
            }
            else
            {
                damagezone.ReportDamage(health);
                damageTaken += health;
            }

            health -= damagezone.DamagePerCheck;
            healthupdate.Invoke(ID, health);

            if (health <= 0)
            {
                damagezone.ReportPoint();
                Die();
            }
        }
        else if (attack != null && ID != attack.CheckID())
        {
            if (health >= attack.damage)
            {
                attack.ReportDamage(attack.damage);
                damageTaken += attack.damage;
            }
            else
            {
                attack.ReportDamage(health);
                damageTaken += health;
            }

            health -= other.GetComponent<PlayerAttack>().damage;
            healthupdate.Invoke(ID, health);

            if (health <= 0)
            {
                other.GetComponent<PlayerAttack>().ReportPoint();
                Die();
            }
        }

    }


    public void IncreaseScore()
    {
        score += 1 + numTowers;
    }

    private void Die()
    {
        dead = true;
        fire = air = water = earth = false;
        chargeWaterSpell = 0.0f;
        chargeIceSpell = 0.0f;

        health = 0.0f;
        
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

    private void selectCharacter()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = characterList[PlayerPrefs.GetInt("Player" + ID)];
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
