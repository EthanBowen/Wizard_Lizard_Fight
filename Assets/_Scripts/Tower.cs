using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //check for the owner of the tower
    public int ID = 0;
    //To seperate the players and hold each of their values]
    public Player owner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CaptureTower(Player newOwner)
    {
        owner.numTowers--;
        newOwner.numTowers++;
        owner = newOwner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            CaptureTower(player);
        
        else
            owner = collision.gameObject.GetComponent<Player>();
    }   


}
