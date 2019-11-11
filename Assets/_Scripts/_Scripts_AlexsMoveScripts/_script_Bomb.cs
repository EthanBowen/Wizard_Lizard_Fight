using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_Bomb : MonoBehaviour
{
    public bool ExplodeManually = false;
    public float FuseTimer = 3.0f;
    public float ExplosionRadius = 1.5f;
    public float ExplosionKnockback = 1.0f;
    public float ExplosionDamage = 30.0f;
    public bool CanDamageDropper = true;
    public GameObject ExplosionPrefab;

    public bool LeavesFireAfterExplosion = false;
    [Header("Post-Explosion Fire Settings:")]
    public float FireDuration = 2f;
    public float FireRadius = 0.5f;
    public float FireDamagePerCheck = 10.0f;
    public enum SpreadType
    {
        Plus,
        Circle,
        Spot
    };
    public SpreadType FireSpreadType = SpreadType.Plus;

    public GameObject FireZonePlus;
    public GameObject FireZoneCircle;
    public GameObject FireZoneSpot;

    private float Timer = 0.0f;
    private Player owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ExplodeManually)
        {
            Timer += Time.deltaTime;
            if (Timer > FuseTimer)
            {
                Detonate();
            }
        }
    }

    public void SetOwner(Player own)
    {
        owner = own;
    }

    /**
     * Handles what happens when the bomb detonates.
     */
    public void Detonate()
    {
        Debug.Log("----- Player " + PlayerID + "'s Bomb Exploded");
        // Spawn explosion collider
        Explode();
        // Spawn fire spots
        if (LeavesFireAfterExplosion)
        {
            PlaceFire();
        }
        // Destroys self
        Destroy(this.gameObject);
    }

    /**
     * When the bomb explodes, summons a trigger zone prefab that handles damaging and pushing the player.
     * 
     */
    void Explode()
    {
        if (ExplosionPrefab != null)
        {
            GameObject explosion = Instantiate(ExplosionPrefab);
            explosion.transform.position = this.transform.position;
            explosion.GetComponent<_script_KnockbackTrigger>().Damage = ExplosionDamage;
            explosion.GetComponent<_script_KnockbackTrigger>().Knockback = ExplosionKnockback;
            explosion.GetComponent<_script_KnockbackTrigger>().owner = owner;

            // Place explosion prefab.
            // Prefab will apply collision event that adds force to player's movement in direction opposite to bomb's center.

        }
    }

    /**
     * Places the damaging fire after an explosion, if this bomb drops it.
     */
    void PlaceFire()
    {
        GameObject Fire;
        switch (FireSpreadType)
        {
            case (SpreadType.Plus):
                Fire = Instantiate(FireZonePlus);
                break;
            case (SpreadType.Circle):
                Fire = Instantiate(FireZoneCircle);
                break;
            case (SpreadType.Spot):
                Fire = Instantiate(FireZoneSpot);
                break;
            default:
                Fire = Instantiate(FireZonePlus);
                break;
        }
        if (Fire != null)
        {
            Fire.transform.position = this.transform.position;
            Fire.transform.localScale = new Vector3(FireRadius, FireRadius, 1.0f);
            foreach (_script_DamageZone zone in Fire.GetComponentsInChildren<_script_DamageZone>()) {
                zone.DamagePerCheck = FireDamagePerCheck;
                zone.Lifetime = FireDuration;
                zone.PlayerID = PlayerID;
                zone.owner = owner;
                zone.gameObject.transform.parent = null;
            }
            Destroy(Fire);
        }
        // If the fire prefab requested cannot be found, ignore attempting to summon it.
    }

    private int PlayerID = 0;

    public void SetPlayerID(int ID)
    {
        PlayerID = ID;
    }



}
