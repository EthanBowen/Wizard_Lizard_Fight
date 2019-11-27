using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //check for the owner of the tower
    public int ID = 0;
    public Transform bar;
    public GameObject CaptureBar;
    //public int CapturingID;
    public float captureTime = 100f;
    public float time = 0.0f;
    //private bool capturingTower;
    private bool towerCaptured;
    public bool capping;
    public List<Player> capturingPlayers;
    //To seperate the players and hold each of their values]
    public Player owner;
    
    // Start is called before the first frame update
    void Start()
    {
        towerCaptured = false;
        capping = false;
        owner = null;
        time = 0f;
        //bar = transform.Find("Bar");
        bar.localScale = new Vector3(0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (capturingPlayers.Count > 0)
        {
            if (capturingPlayers.Count == 1 && capturingPlayers[0].ID != ID)
            {
                time += 1f;
                CaptureBar.SetActive(true);
            }
            else
            {

            }
            if (time >= 100)
            {
                CaptureTower(capturingPlayers[0]);
            }
        }
        else
        {
            time = 0f;
            CaptureBar.SetActive(false);
        }
        bar.localScale = new Vector3((time / captureTime)*1.5f, 1.5f);
    }
    public void CapturingTower()
    {
        //if(capping)
            //if(time != (captureTime / 2))
                //bar.localScale = new Vector3((time/captureTime) / 2, 0.5f);
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
        //capping = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null && capturingPlayers.Contains(player))
        {
            if (player.ID != capturingPlayers[0].ID)
                time = 0f;
            //capping = false;
            capturingPlayers.Remove(player);
        }
    }
    

}
