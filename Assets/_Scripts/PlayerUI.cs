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
       sr = gameObject.AddComponent<SpriteRenderer>();
       playerSprite = characterList[0];
       if (sr.sprite == null)
           sr.sprite = playerSprite;

       //sets the locations of all players spawned in their respected corners of the screen
       switch (ID)
       {
            case 1: //top left player
                this.x = 0.118f;
                this.y = .940f;
                HP.x = 0.118f;
                HP.y = .960f;
                MP.x = 0.118f;
                MP.y = 0.943f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                HP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                MP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 2: //top right player
                this.x = 1 - 0.118f;
                this.y = 0.940f;
                HP.x = 1 - 0.118f;
                HP.y = .960f;
                MP.x = 1 - 0.118f;
                MP.y = 0.943f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                HP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                MP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 3: //bottom left player
                this.x = 0.118f;
                this.y = 1 - 0.940f;
                HP.x = 0.118f;
                HP.y = 1 - 0.950f;
                MP.x = 0.118f;
                MP.y = 1 - 0.970f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                HP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                MP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 4: //bottom right player
                this.x = 1-0.118f;
                this.y = 1 - 0.940f;
                HP.x = 1 - 0.118f;
                HP.y = 1 - 0.950f;
                MP.x = 1 - 0.118f;
                MP.y = 1 - 0.970f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                HP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                MP.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
       }
    }

    // Update is called once per frame
    void Update()
    {
        health = player.health;
        mana = player.MP;
        //WIP to figure out with Character Selection for later
        if (Input.GetKeyDown(KeyCode.Space))
            ChangePlayerSprite();
            
    }

    private void ChangePlayerSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = characterList[characterList.Length-1];
    }
    
}
