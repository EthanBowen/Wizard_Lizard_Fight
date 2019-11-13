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
    public GameObject playerPicture;
    public float health = 0;
    public float mana = 0;
    public Sprite playerSprite;
    public Sprite[] characterList;
    // Start is called before the first frame update
    void Start()
    {
       UI_Camera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
               
       //sets the locations of all players spawned in their respected corners of the screen
       switch (ID)
       {
            case 1: //top left player
                x = 0.04f;
                y = .900f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
            case 2: //top right player
                x = 1 - 0.15f;
                y = 0.900f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));

                break;
            case 3: //bottom left player
                x = 0.04f;
                y = 1 - 0.900f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
            case 4: //bottom right player
                x = 1 - 0.15f;
                y = 1 - 0.900f;
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
    }

    private void ChangePlayerSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = characterList[characterList.Length-1];
    }

    private void showSelectedCharacter()
    {
        switch(ID)
        {
            case (1): //top left player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player1")];
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.05f, 0.900f, 10f));
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                break;
            case (2): //top right player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player2")];
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.945f, 0.900f, 10f));
                playerPicture.GetComponent<SpriteRenderer>().flipX = true;
                break;
            case (3): //bottom left player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player3")];
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(0.05f,1 - 0.900f, 10f));
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                break;
            case (4): //bottom right player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player4")];
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.945f, 1 - 0.900f, 10f));
                playerPicture.GetComponent<SpriteRenderer>().flipX = true;
                break;
        }
        
    }
}
