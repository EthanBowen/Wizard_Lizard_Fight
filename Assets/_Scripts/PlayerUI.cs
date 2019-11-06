using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public int ID = 0;
    private float x = 0;
    private float y = 0;
    private Camera UI_Camera = new Camera();
    public Player player;
    public HealthBar HP;
    public ManaBar MP;
    public float health = 0;
    public float mana = 0;
    public Sprite playerSprite;
    public Sprite[] characterList;
    //GameObject healthbar = Instantiate(Resources.Load("HealthBarPrefab"), new Vector3(0.118f, .960f, 5f), Quaternion.identity) as GameObject;
   // GameObject manabar = Instantiate(Resources.Load("ManaBarPrefab"), new Vector3(0.118f, 0.943f, 5f), Quaternion.identity) as GameObject;

    //public Sprite playerSprite2;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
       UI_Camera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
       //WIP Character models next to UI
       //sr = gameObject.AddComponent<SpriteRenderer>();
       //playerSprite = characterList[0];
       //if (sr.sprite == null)
        //   sr.sprite = playerSprite;
       //brings the picture of the sprite in front of the HP and MP bars
        
       //sets the locations of all players spawned in their respected corners of the screen
       switch (ID)
       {
            case 1: //top left player
                x = 0.118f;
                y = .940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
            case 2: //top right player
                x = 1 - 0.118f;
                y = 0.940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
            case 3: //bottom left player
                x = 0.118f;
                y = 1 - 0.940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
            case 4: //bottom right player
                x = 1-0.118f;
                y = 1 - 0.940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
       }
        showSelectedCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        health = player.health;
        mana = player.MP;
        //WIP to figure out with Character Selection for later
        //if (Input.GetKeyDown(KeyCode.Space))
        // ChangePlayerSprite();

    }

    private void ChangePlayerSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = characterList[characterList.Length-1];
    }

    private void showSelectedCharacter()
    {
        switch(ID)
        {
            case (1):
                this.gameObject.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player1")];
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
                break;
            case (2):
                this.gameObject.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player2")];
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
                break;
            case (3):
                this.gameObject.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player3")];
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
                break;
            case (4):
                this.gameObject.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player4")];
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
                break;
        }
        
    }
}
