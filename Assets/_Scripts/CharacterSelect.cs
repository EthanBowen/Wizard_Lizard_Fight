using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    //player ID
    public int ID = 1;
    //Player panels
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public bool player1Ready;
    public bool player2Ready;
    public bool player3Ready;
    public bool player4Ready;

    private int playerCharacter;
    //to track the players choice for character
    public int player1SelectedCharacterIndex;
    public int player2SelectedCharacterIndex;
    public int player3SelectedCharacterIndex;
    public int player4SelectedCharacterIndex;
    //color of the character
    private Color player1CharacterColor;
    private Color player2CharacterColor;
    private Color player3CharacterColor;
    private Color player4CharacterColor;

    [Header("List of Characters")]
    [SerializeField] public List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();
     private List<CharacterSelectObject> player1CharacterList = new List<CharacterSelectObject>();
     private List<CharacterSelectObject> player2CharacterList = new List<CharacterSelectObject>();
     private List<CharacterSelectObject> player3CharacterList = new List<CharacterSelectObject>();
     private List<CharacterSelectObject> player4CharacterList = new List<CharacterSelectObject>();

    public int characterListCount;

    [Header("UI Reference")]

    [SerializeField] private TextMeshProUGUI player1Name;
    [SerializeField] private TextMeshProUGUI player2Name;
    [SerializeField] private TextMeshProUGUI player3Name;
    [SerializeField] private TextMeshProUGUI player4Name;

    [SerializeField] private Image player1Splash;
    [SerializeField] private Image player2Splash;
    [SerializeField] private Image player3Splash;
    [SerializeField] private Image player4Splash;

    [SerializeField] private Image player1Color;
    [SerializeField] private Image player2Color;
    [SerializeField] private Image player3Color;
    [SerializeField] private Image player4Color;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip arrowSFX;
    [SerializeField] private AudioSource characterSelectMusic;

    [Header("Small Changes")]
    [SerializeField] private float backgroundColorTransitionSpeed = 1.0f;

    private void Start()
    {
        //selectedCharacterIndex = PlayerPrefs.GetInt("CharacterSelected");
        //updateCharacterSelectUI(ID);
        player1Splash.sprite = characterList[0].splash;
        player1CharacterColor = characterList[0].characterColor;
        player1Name.text = characterList[0].characterName;
        populateCharacterList();
        characterSelectMusic.Play();
    }

    private void Update()
    {
        characterListCount = characterList.Count;
        countPlayers();
        //slowly changes the background color to the designated color of the player character background
        backgroundColorChanger();
        playerTracker();
        if (player1Ready && player2Ready && player3Ready && player4Ready)
            return; //TODO: Transition scene to the game scene
    }
    /**
     *Adds all characters from the main Character list to the rest of the Player Character Lists
     */
    private void populateCharacterList()
    {
        for (int index = 0; index < characterList.Count; index++)
        {
                player1CharacterList.Add(characterList[index]);

                player2CharacterList.Add(characterList[index]);

                player3CharacterList.Add(characterList[index]);

                player4CharacterList.Add(characterList[index]);
        }
    }
    /**
     * Counts all the players that is currently playing
     */
    private void countPlayers()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) && ID < 3)
        {
            if (ID == 4)
                return;
            else
                ID++;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Delete) && ID > 1)
        {
            if (ID == 1)
                return;
            else
                ID--;
        }
             
    }
    /**
     * Changes the background color depending on the player
     */
    private void backgroundColorChanger()
    {
        switch(ID)
        {
            case (1):
                player1Color.color = Color.Lerp(player1Color.color, player1CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
                break;
            case (2):
                player2Color.color = Color.Lerp(player2Color.color, player2CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
                break;
            case (3):
                player3Color.color = Color.Lerp(player3Color.color, player3CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
                break;
            case (4):
                player4Color.color = Color.Lerp(player4Color.color, player4CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
                break;

        }   
    }
    //Meant to store the information on multiple players
    public void playerTracker()
    {
        switch(ID)
        {
            case (1):
                Player1.GetComponent<PlayerController>().ID = ID;
                Player2.SetActive(false);
                Player3.SetActive(false);
                Player4.SetActive(false);
                playerCharacter = player1SelectedCharacterIndex;
                break;
            case (2):
                Player2.AddComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(false);
                Player4.SetActive(false);
                playerCharacter = player2SelectedCharacterIndex;
                break;
            case (3):
                Player3.AddComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(true);
                Player4.SetActive(false);
                playerCharacter = player3SelectedCharacterIndex;
                break;
            case (4):
                Player4.AddComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(true);
                Player4.SetActive(true);
                playerCharacter = player4SelectedCharacterIndex;
                break;
        }
    }
    /**
     * Cycles forward in the list of the characters
     * toggles off the ready for the player to signify that they are not ready to choose a character
     */
    public void leftArrow()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            return;
        switch (ID)
        {
            case (1):
                player1Ready = false;
                player1SelectedCharacterIndex--;
                if (player1SelectedCharacterIndex < 0)
                    player1SelectedCharacterIndex = player1CharacterList.Count - 1;
                break;
            case (2):
                player2Ready = false;
                player2SelectedCharacterIndex--;
                if (player2SelectedCharacterIndex < 0)
                    player2SelectedCharacterIndex = player2CharacterList.Count - 1;
                break;
            case (3):
                player3Ready = false;
                player3SelectedCharacterIndex--;
                if (player3SelectedCharacterIndex < 0)
                    player3SelectedCharacterIndex = player3CharacterList.Count - 1;
                break;
            case 4:
                player4Ready = false;
                player4SelectedCharacterIndex--;
                if (player4SelectedCharacterIndex < 0)
                    player4SelectedCharacterIndex = player4CharacterList.Count - 1;
                break;
        }

        updateCharacterSelectUI(ID);

        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
    }
    /**
     * Cycles forward in the list of the characters
     * toggles off the ready for the player to signify that they are not ready to choose a character
     */
    public void rightArrow()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            return;
        switch(ID)
        {
            case (1):
                player1Ready = false;
                player1SelectedCharacterIndex++;
                if (player1SelectedCharacterIndex == player1CharacterList.Count)
                    player1SelectedCharacterIndex = 0;
                break;
            case (2):
                player2Ready = false;
                player2SelectedCharacterIndex++;
                if (player2SelectedCharacterIndex == player2CharacterList.Count)
                    player2SelectedCharacterIndex = 0;
                break;
            case (3):
                player3Ready = false;
                player3SelectedCharacterIndex++;
                if (player3SelectedCharacterIndex == player3CharacterList.Count)
                    player3SelectedCharacterIndex = 0;
                break;
            case 4:
                player4Ready = false;
                player4SelectedCharacterIndex++;
                if (player4SelectedCharacterIndex == player4CharacterList.Count)
                    player4SelectedCharacterIndex = 0;
                break;
        }

        updateCharacterSelectUI(ID);

        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
    }

    public void Confirm()
    {
        //TODO: make this function save the information the player chooses
        switch(ID)
        {
            case (1):
                PlayerPrefs.SetInt("Player1", player1SelectedCharacterIndex);
                player1Ready = true;
                break;
            case (2):
                PlayerPrefs.SetInt("Player2", player2SelectedCharacterIndex);
                player2Ready = true;
                break;
            case (3):
                PlayerPrefs.SetInt("Player3", player3SelectedCharacterIndex);
                player3Ready = true;
                break;
            case (4):
                PlayerPrefs.SetInt("Player4", player4SelectedCharacterIndex);
                player4Ready = true;
                break;
        }
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
    }
    public void updateCharacterSelectUI(int player)
    {
        //Sets the Splash, Name, Color
        switch (player)
        {
            case (1):
                player1Splash.sprite = player1CharacterList[player1SelectedCharacterIndex].splash;
                player1Name.text = player1CharacterList[player1SelectedCharacterIndex].characterName;
                player1CharacterColor = player1CharacterList[player1SelectedCharacterIndex].characterColor;
                break;
            case (2):
                player2Splash.sprite = player2CharacterList[player2SelectedCharacterIndex].splash;
                player2Name.text = player2CharacterList[player2SelectedCharacterIndex].characterName;
                player2CharacterColor = player2CharacterList[player2SelectedCharacterIndex].characterColor;
                break;
            case (3):
                player3Splash.sprite = player3CharacterList[player3SelectedCharacterIndex].splash;
                player3Name.text = player3CharacterList[player3SelectedCharacterIndex].characterName;
                player3CharacterColor = player3CharacterList[player3SelectedCharacterIndex].characterColor;
                break;
            case 4:
                player4Splash.sprite = player4CharacterList[player4SelectedCharacterIndex].splash;
                player4Name.text = player4CharacterList[player4SelectedCharacterIndex].characterName;
                player4CharacterColor = player4CharacterList[player4SelectedCharacterIndex].characterColor;
                break;
        }
        
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color characterColor;
    }
}
