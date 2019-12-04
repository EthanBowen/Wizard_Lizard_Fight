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
    public Sprite[] playerColorPortrait;

    public Transform HealthBar;
    public Transform ManaBar;
    public Transform ScoreBar;

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
                x = 1 - 0.04f;
                y = 0.900f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));

                break;
            case 3: //bottom left player
                x = 0.04f;
                y = 1 - 0.900f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 10f));
                break;
            case 4: //bottom right player
                x = 1 - 0.040f;
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
        float leftSideOffset = gameObject.transform.position.x - HealthBar.position.x;
        switch (ID)
        {
            case (1): //top left player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player1")];
                scoreText.transform.localPosition = new Vector3(-780f, 401f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerColor.GetComponent<SpriteRenderer>().sprite = playerColorPortrait[0];
                break;
            case (2): //top right player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player2")];
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                scoreText.transform.localPosition = new Vector3(775f, 401f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().flipX = true;
                playerColor.GetComponent<SpriteRenderer>().sprite = playerColorPortrait[1];
                playerColor.GetComponent<SpriteRenderer>().flipX = true;
                HealthBar.position = new Vector3(HealthBar.position.x + (leftSideOffset*2), HealthBar.position.y, HealthBar.position.z);
                ManaBar.position = new Vector3(ManaBar.position.x + (leftSideOffset * 2), ManaBar.position.y, ManaBar.position.z);
                ScoreBar.position = new Vector3(ScoreBar.position.x + (leftSideOffset * 2), ScoreBar.position.y, ScoreBar.position.z);
                break;
            case (3): //bottom left player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player3")];
                scoreText.transform.localPosition = new Vector3(-780f, -463f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                playerColor.GetComponent<SpriteRenderer>().sprite = playerColorPortrait[2];
                break;
            case (4): //bottom right player
                playerPicture.AddComponent<SpriteRenderer>().sprite = characterList[PlayerPrefs.GetInt("Player4")];
                playerPicture.GetComponent<SpriteRenderer>().sortingOrder = 100;
                scoreText.transform.localPosition = new Vector3(775f, -463f, 10f);
                playerPicture.GetComponent<SpriteRenderer>().flipX = true;
                playerColor.GetComponent<SpriteRenderer>().sprite = playerColorPortrait[3];
                playerColor.GetComponent<SpriteRenderer>().flipX = true;
                HealthBar.position = new Vector3(HealthBar.position.x + (leftSideOffset * 2), HealthBar.position.y, HealthBar.position.z);
                ManaBar.position = new Vector3(ManaBar.position.x + (leftSideOffset * 2), ManaBar.position.y, ManaBar.position.z);
                ScoreBar.position = new Vector3(ScoreBar.position.x + (leftSideOffset * 2), ScoreBar.position.y, ScoreBar.position.z);
                break;
        }
        
    }
}
