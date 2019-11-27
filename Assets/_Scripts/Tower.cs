using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //check for the owner of the tower
    public int ID = 0;
    //public int CapturingID;
    public float captureTime = 100f;
    public float time = 0.0f;
    //private bool capturingTower;
    private bool towerCaptured;
    public List<Player> capturingPlayers;
    //To seperate the players and hold each of their values]
    public Player owner;
    
    // Start is called before the first frame update
    void Start()
    {
        towerCaptured = false;
        owner = null;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (capturingPlayers.Count > 0)
        {
            if (capturingPlayers.Count == 1 && capturingPlayers[0].ID != ID)
            {
                time += 1f;
            }
            if (time >= 100)
            {
                CaptureTower(capturingPlayers[0]);
            }
        }
        else
        {
            time = 0f;
        }
    }
    private void CapturingTower()
    {

    }

    private void CaptureTower(Player newOwner)
    {
        if(towerCaptured)
            owner.numTowers--;

        newOwner.numTowers++;
        owner = newOwner;
        ID = newOwner.ID;
        GetComponent<Animator>().SetInteger("ID", ID);
        //this.GetComponent<SpriteRenderer>().color = owner.GetComponent<SpriteRenderer>().color;
        towerCaptured = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null && !capturingPlayers.Contains(player))
            capturingPlayers.Add(player);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null && capturingPlayers.Contains(player))
        {
            if (player.ID != capturingPlayers[0].ID)
                time = 0f;
            capturingPlayers.Remove(player);
        }
    }
    

}
