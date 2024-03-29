﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
   public float PlayerMaxMana = 100f;
    private Transform bar;
    public float CurrentPlayerMana = 0.0f;
    public Player player;
    public int ID = 0;
    private Camera UI_Camera = new Camera();
    public PlayerUI playerUI;
    //private Player player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMaxMana = player.maxMP;
        CurrentPlayerMana = PlayerMaxMana;
        bar = transform.Find("Bar");
        ID = playerUI.ID;
        UI_Camera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
        /*
        switch (ID)
        {
            case 1: //top left player
                x = 0.118f;
                y = .943f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 2: //top right player
                x = 1 - 0.118f;
                y = .943f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 3: //bottom left player
                x = 0.118f;
                y = 1 - .970f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 4: //bottom right player
                x = 1 - 0.118f;
                y = 1 - .970f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
        }
        */
        
    }

    private void Update()
    {
        setMana(playerUI.mana);
    }
    
    public void setMana(float mana)
    {
        //CurrentPlayerMana = player.MP;
        float hp = (mana / PlayerMaxMana);
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
}
