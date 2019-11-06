using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public int ID;
    private PlayerUI player;
    private int playerCharacter;

    private int selectedCharacterIndex;
    private Color desiredColor;

    [Header("List of Characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image characterColor;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip arrowSFX;
    [SerializeField] private AudioSource characterSelectMusic;

    [Header("Small Changes")]
    [SerializeField] private float backgroundColorTransitionSpeed = 1.0f;

    private void Start()
    {
        updateCharacterSelectUI();
        characterSelectMusic.Play();
    }
    private void Update()
    {
        //slowly changes the background color to the designated color of the player character background
        characterColor.color = Color.Lerp(characterColor.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
    }
    //Meant to store the information on multiple players
    public void playerTracker()
    {
        switch(ID)
        {
            case (0):
                playerCharacter = selectedCharacterIndex;
                break;
            case (1):
                playerCharacter = selectedCharacterIndex;
                break;
            case (2):
                playerCharacter = selectedCharacterIndex;
                break;
            case (3):
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
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
    }
    private void updateCharacterSelectUI()
    {
        //Sets the Splash, Name, Color
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;
        characterName.text = characterList[selectedCharacterIndex].characterName;
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
