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
    public int selectedCharacterIndex;
    //color of the character
    private Color player1CharacterColor;
    private Color player2CharacterColor;
    private Color player3CharacterColor;
    private Color player4CharacterColor;

    [Header("List of Characters")]
    [SerializeField] public List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();
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
        selectedCharacterIndex = PlayerPrefs.GetInt("CharacterSelected");
        updateCharacterSelectUI();
        characterSelectMusic.Play();
    }
    private void Update()
    {
        characterListCount = characterList.Count;
        countPlayers();
        //slowly changes the background color to the designated color of the player character background
        backgroundColorChanger();
        playerTracker();
    }
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
    private void backgroundColorChanger()
    {
        switch(ID)
        {
            case (1):
                player1Color.color = Color.Lerp(player1Color.color, player1CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
                break;
            case (2):
                player2Color.color = Color.Lerp(player2Color.color, player1CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
                break;
            case (3):
                player3Color.color = Color.Lerp(player3Color.color, player1CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
                break;
            case (4):
                player4Color.color = Color.Lerp(player4Color.color, player1CharacterColor, Time.deltaTime * backgroundColorTransitionSpeed);
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
                playerCharacter = selectedCharacterIndex;
                break;
            case (2):
                Player2.GetComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(false);
                Player4.SetActive(false);
                playerCharacter = selectedCharacterIndex;
                break;
            case (3):
                Player3.GetComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(true);
                Player4.SetActive(false);
                playerCharacter = selectedCharacterIndex;
                break;
            case (4):
                Player4.GetComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(true);
                Player4.SetActive(true);
                playerCharacter = selectedCharacterIndex;
                break;
        }
    }
    public void leftArrow()
    {
        switch (ID)
        {
            case (1):
                player1Ready = false;
                break;
            case (2):
                player2Ready = false;
                break;
            case (3):
                player3Ready = false;
                break;
            case 4:
                player4Ready = false;
                break;
        }
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
            selectedCharacterIndex = characterList.Count - 1;

        updateCharacterSelectUI();

        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
    }

    public void rightArrow()
    {
        switch(ID)
        {
            case (1):
                player1Ready = false;
                selectedCharacterIndex++;
                if (selectedCharacterIndex == characterList.Count)
                    selectedCharacterIndex = 0;
                break;
            case (2):
                player2Ready = false;
                selectedCharacterIndex++;
                if (selectedCharacterIndex == characterList.Count)
                    selectedCharacterIndex = 0;
                break;
            case (3):
                player3Ready = false;
                selectedCharacterIndex++;
                if (selectedCharacterIndex == characterList.Count)
                    selectedCharacterIndex = 0;
                break;
            case 4:
                player4Ready = false;
                selectedCharacterIndex++;
                if (selectedCharacterIndex == characterList.Count)
                    selectedCharacterIndex = 0;
                break;
        }

        updateCharacterSelectUI();

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
                PlayerPrefs.SetInt("Player1", selectedCharacterIndex);
                player1Ready = true;
                break;
            case (2):
                PlayerPrefs.SetInt("Player2", selectedCharacterIndex);
                player2Ready = true;
                break;
            case (3):
                PlayerPrefs.SetInt("Player3", selectedCharacterIndex);
                player3Ready = true;
                break;
            case (4):
                PlayerPrefs.SetInt("Player4", selectedCharacterIndex);
                player4Ready = true;
                break;
        }
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
    }
    public void updateCharacterSelectUI()
    {
        //Sets the Splash, Name, Color
        switch (ID)
        {
            case (1):
                player1Splash.sprite = characterList[selectedCharacterIndex].splash;
                player1Name.text = characterList[selectedCharacterIndex].characterName;
                player1CharacterColor = characterList[selectedCharacterIndex].characterColor;
                break;
            case (2):
                player2Splash.sprite = characterList[selectedCharacterIndex].splash;
                player2Name.text = characterList[selectedCharacterIndex].characterName;
                player2CharacterColor = characterList[selectedCharacterIndex].characterColor;
                break;
            case (3):
                player3Splash.sprite = characterList[selectedCharacterIndex].splash;
                player3Name.text = characterList[selectedCharacterIndex].characterName;
                player3CharacterColor = characterList[selectedCharacterIndex].characterColor;
                break;
            case 4:
                player4Splash.sprite = characterList[selectedCharacterIndex].splash;
                player4Name.text = characterList[selectedCharacterIndex].characterName;
                player4CharacterColor = characterList[selectedCharacterIndex].characterColor;
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
