using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //check for the owner of the tower
    public int ID = 0;
    public int CapturingID;
    private float captureTime = 10f;
    private bool capturingTower;
    private bool towerCaptured;
    private List<Player> capturingPlayers;
    //To seperate the players and hold each of their values]
    public Player owner;
    
    // Start is called before the first frame update
    void Start()
    {
        towerCaptured = false;
        owner = null;
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       // if(capturingPlayers.Count > 0)
        //{
        //    if(capturingPlayers.Count == 1)
       //         ID = capturingPlayers
       // }
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
        this.GetComponent<SpriteRenderer>().color = owner.GetComponent<SpriteRenderer>().color;
        towerCaptured = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

       // capturingPlayers.Add(player);

        if (player != null)
            CaptureTower(player);
        //    return;
       // owner = collision.gameObject.GetComponent<Player>();
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        capturingPlayers.Remove(player);
    }
    */

}
