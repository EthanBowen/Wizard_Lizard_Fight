using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text scoreText;
    public GameObject playerColor;
    public float health = 0;
    public float mana = 0;
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
                x = 1 - 0.143f;
                y = 0.900f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));

                break;
            case 3: //bottom left player
                x = 0.04f;
                y = 1 - 0.900f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
            case 4: //bottom right player
                x = 1 - 0.143f;
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
        scoreText.text = "Score: " + player.score + " Towers: " + player.numTowers;
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
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.035f, 0.860f, 10f));
                scoreText.transform.localPosition = new Vector3(-780f, 401f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerColor.GetComponent<SpriteRenderer>().color = Color.blue;
                playerColor.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(0.035f, 0.900f, 10f));
                break;
            case (2): //top right player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player2")];
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.965f, 0.860f, 10f));
                scoreText.transform.localPosition = new Vector3(775f, 401f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().flipX = true;
                playerColor.GetComponent<SpriteRenderer>().color = Color.red;
                playerColor.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.965f, 0.900f, 10f));
                break;
            case (3): //bottom left player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player3")];
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(0.035f, 1 - 0.940f, 10f));
                scoreText.transform.localPosition = new Vector3(-780f, -463f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerColor.GetComponent<SpriteRenderer>().color = Color.green;
                playerColor.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(0.035f, 1 - 0.900f, 10f));
                break;
            case (4): //bottom right player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player4")];
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerPicture.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.965f, 1 - 0.940f, 10f));
                scoreText.transform.localPosition = new Vector3(775f, -463f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().flipX = true;
                playerColor.GetComponent<SpriteRenderer>().color = Color.yellow;
                playerColor.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(.965f, 1 - 0.900f, 10f));
                break;
        }
        
    }
}
