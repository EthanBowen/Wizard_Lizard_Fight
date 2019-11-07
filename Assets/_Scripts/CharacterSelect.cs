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

    private int playerCharacter;
    //to track the players choice for character
    private int selectedCharacterIndex;
    //color of the character
    private Color desiredColor;

    [Header("List of Characters")]
    [SerializeField] public List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

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
        //slowly changes the background color to the designated color of the player character background
        player1Color.color = Color.Lerp(player1Color.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
        player2Color.color = Color.Lerp(player2Color.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
        player3Color.color = Color.Lerp(player3Color.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
        player4Color.color = Color.Lerp(player4Color.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
        countPlayers();
        switch(ID)
        {
            case (1):
                Player2.SetActive(false);
                Player3.SetActive(false);
                Player4.SetActive(false);
                break;
            case (2):
                Player2.SetActive(true);
                Player3.SetActive(false);
                Player4.SetActive(false);
                break;
            case (3):
                Player2.SetActive(true);
                Player3.SetActive(true);
                Player4.SetActive(false);
                break;
            case (4):
                Player2.SetActive(true);
                Player3.SetActive(true);
                Player4.SetActive(true);
                break;
        }
    }
    private void countPlayers()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) && ID < 4)
             ID++;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Delete) && ID > 1)
             ID--;
    }
    //Meant to store the information on multiple players
    public void playerTracker()
    {
        switch(ID)
        {
            case (1):
                playerCharacter = selectedCharacterIndex;
                break;
            case (2):
                playerCharacter = selectedCharacterIndex;
                break;
            case (3):
                playerCharacter = selectedCharacterIndex;
                break;
            case (4):
                playerCharacter = selectedCharacterIndex;
                break;
        }
    }
    public void leftArrow()
    {
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
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count)
            selectedCharacterIndex = 0;

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
                break;
            case (2):
                PlayerPrefs.SetInt("Player2", selectedCharacterIndex);
                break;
            case (3):
                PlayerPrefs.SetInt("Player3", selectedCharacterIndex);
                break;
            case (4):
                PlayerPrefs.SetInt("Player4", selectedCharacterIndex);
                break;
        }
        
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
    }
    private void updateCharacterSelectUI()
    {
        //Sets the Splash, Name, Color
        player1Splash.sprite = characterList[selectedCharacterIndex].splash;
        player1Name.text = characterList[selectedCharacterIndex].characterName;
        player2Splash.sprite = characterList[selectedCharacterIndex].splash;
        player2Name.text = characterList[selectedCharacterIndex].characterName;
        player3Splash.sprite = characterList[selectedCharacterIndex].splash;
        player3Name.text = characterList[selectedCharacterIndex].characterName;
        player4Splash.sprite = characterList[selectedCharacterIndex].splash;
        player4Name.text = characterList[selectedCharacterIndex].characterName;
        desiredColor = characterList[selectedCharacterIndex].characterColor;
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color characterColor;
    }
}
