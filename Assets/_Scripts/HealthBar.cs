using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float PlayerMaxHealth = 1000.0f;
    private Transform bar;
    public float CurrentPlayerHealth = 0.0f;
    public Player player;
    public int ID = 0;
    private Camera UI_Camera = new Camera();
    public PlayerUI playerUI;
    //private Player player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMaxHealth = player.maxHealth;
        CurrentPlayerHealth = PlayerMaxHealth;
        ID = playerUI.ID;
        bar = transform.Find("Bar");
        UI_Camera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
        //this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x,y,5f));
        /*
        switch (ID)
        {
            case 1: //top left player
                x = 0.118f;
                y = .960f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 2: //top right player
                x = 1-0.118f;
                y = .960f;
               this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 3: //bottom left player
                x = 0.118f;
                y = 1 - .950f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 4: //bottom right player
                x = 1 - 0.118f;
                y = 1 - .950f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
        }
        */
        
    }

    private void Update()
    {
        setHealth(playerUI.health);
    }

    /**
     * This method fires AFTER Update(), and is generally good for UI elements that wait upon values changing, like HP.
     */
    private void LateUpdate()
    {
        
    }

    public void setSize()
    {
        float hp = (CurrentPlayerHealth / PlayerMaxHealth);
        if (float.IsNaN(hp))
            hp = player.health;
        bar.localScale = new Vector3(hp, 1f);
    }
    
    public void setHealth(float health)
    {
        //CurrentPlayerHealth = player.health;
        float hp = (health / PlayerMaxHealth);
        switch (ID)
        {
            case 1:
                bar.localScale = new Vector3(hp, 1f);
                break;
            case 2:
                bar.localScale = new Vector3(-hp, 1f);
                bar.localPosition = new Vector3(2f, 0);
                break;
            case 3:
                bar.localScale = new Vector3(hp, 1f);
                break;
            case 4:
                bar.localScale = new Vector3(-hp, 1f);
                bar.localPosition = new Vector3(2f, 0f);
                break;

        }
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
