using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //check for the owner of the tower
    private int ID = 0;
    public GameObject barSprite;
    public Transform bar;
    public GameObject CaptureBar;

    public float captureTime = 100f;
    private float time = 0.0f;

    private bool towerCaptured;
    private List<Player> capturingPlayers;
    //To seperate the players and hold each of their values]
    public Player owner;

    private Dictionary<int, Color> PlayerColors;
    
    // Start is called before the first frame update
    void Start()
    {
        towerCaptured = false;
        owner = null;
        time = 0f;
        capturingPlayers = new List<Player>();
        bar.localScale = new Vector3(0, 1.5f);

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)gameObject.transform.position.y;

        PlayerColors = new Dictionary<int, Color>();
        PlayerColors.Add(1, Color.blue);
        PlayerColors.Add(2, Color.red);
        PlayerColors.Add(3, Color.green);
        PlayerColors.Add(4, Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (capturingPlayers.Count > 0)
        {
            if (capturingPlayers.Count == 1)
            {
                if(capturingPlayers[0].ID != ID)
                {
                    time += 1f;
                    CaptureBar.SetActive(true);
                }
                else
                {
                    CaptureBar.SetActive(false);
                }
            }
            if (time >= 100)
            {
                CaptureTower(capturingPlayers[0]);
                
            }
            barSprite.GetComponent<SpriteRenderer>().color = PlayerColors[capturingPlayers[0].ID];
        }
        else
        {
            time = 0f;
            CaptureBar.SetActive(false);
        }

        bar.localScale = new Vector3((time / captureTime) * 1.5f, 1.5f);

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

        CaptureBar.SetActive(false);
        time = 0.0f;
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
            if (player.ID == capturingPlayers[0].ID)
                time = 0f;
            //capping = false;
            capturingPlayers.Remove(player);
        }
    }
    

}
