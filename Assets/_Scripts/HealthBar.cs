using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float PlayerMaxHealth = 1.0f;
    private Transform bar;
    private float CurrentPlayerHealth = 0.0f;
    public Player player;
    //private Player player;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayerHealth = PlayerMaxHealth;
        bar = transform.Find("Bar");

    }

    private void Update()
    {

    }

    /**
     * This method fires AFTER Update(), and is generally good for UI elements that wait upon values changing, like HP.
     */
    private void LateUpdate()
    {
        setSize();
    }

    public void setSize()
    {
        float hp = (CurrentPlayerHealth / PlayerMaxHealth);
        if (float.IsNaN(hp))
            hp = player.health;
        bar.localScale = new Vector3(hp, 1f);
    }
    

    /**
     * This event is called whenever the player's health changes.
     * 
     */
    public void event_player_healthchanged(int ID, float newHealth)
    {
        CurrentPlayerHealth = newHealth;
    }

}
