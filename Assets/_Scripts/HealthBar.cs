using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float PlayerMaxHealth = 1.0f;
    private Transform bar;
    private float CurrentPlayerHealth = 0.0f;
    public Player player;
    public int ID = 0;
    private float x = 0;
    private float y = 0;
    //private Player player;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayerHealth = PlayerMaxHealth;
        bar = transform.Find("Bar");
        switch (ID)
        {
            case 1:
                x = 0.118f;
                y = .965f;
                this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.118f, .965f, 5f));
                break;
            case 2:
                x = 1-0.118f;
                y = .965f;
               this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3((1 - 0.118f), .965f, 5f));
                break;
            case 3:
                x = 0.118f;
                y = 1 - .965f;
                this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.118f, 1 - .965f, 5f));
                break;
            case 4:
                x = 1 - 0.118f;
                y = 1-.965f;
                this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1 - 0.118f, 1 - .965f, 5f));
                break;
        }
        //this.gameObject.transform.SetParent(Camera.main.transform);

    }

    private void Update()
    {
        //this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 5f));
        //this.gameObject.transform.SetParent(Camera.main.transform);
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
