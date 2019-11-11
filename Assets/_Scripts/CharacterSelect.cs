using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Spine.Unity;
using System;

public class CharacterSelect : MonoBehaviour
{
    //player ID
    public int ID = 1;
    private string currentAnimation1;
    private string currentAnimation2;
    private string currentAnimation3;
    private string currentAnimation4;

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
    public int player1Index;
    public int player2Index;
    public int player3Index;
    public int player4Index;
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

     public TextMeshProUGUI player1Name;
     public TextMeshProUGUI player2Name;
     public TextMeshProUGUI player3Name;
     public TextMeshProUGUI player4Name;

     public SkeletonAnimation player1;
     public AnimationReferenceAsset player1Wizard;
     public SkeletonAnimation player2;
     public AnimationReferenceAsset player2Wizard;
     public SkeletonAnimation player3;
     public AnimationReferenceAsset player3Wizard;
     public SkeletonAnimation player4;
     public AnimationReferenceAsset player4Wizard;

    public Image player1Color;
     public Image player2Color;
     public Image player3Color;
     public Image player4Color;
    
    [Header("Sounds")]
     public AudioSource arrowSFX;
     public AudioSource characterSelectMusic;
     public AudioSource confirmSFX;
    //[SerializeField] private AudioClip characterMusic;

    [Header("Small Changes")]
     private float BackgroundColorTransitionSpeed = 6.0f;

    private void Start()
    {
        player1CharacterColor = characterList[0].characterColor;
        player1Name.text = characterList[0].characterName;
        PopulateCharacterList();
        currentAnimation1 = "The boi_Idle";
        SetCharacterState(currentAnimation1);
        characterSelectMusic.playOnAwake = true;
        characterSelectMusic.loop = true;
    }

    private void Update()
    {
        characterListCount = characterList.Count;
        CountPlayers();
        //slowly changes the background color to the designated color of the player character background
        BackgroundColorChanger(1);
        UpdateCharacterSelectUI(1);
        if(Player2.activeSelf == true)
        {
            UpdateCharacterSelectUI(2);
            BackgroundColorChanger(2);
        }
        if (Player3.activeSelf == true)
        {
            UpdateCharacterSelectUI(3);
            BackgroundColorChanger(3);
        }
        if(Player4.activeSelf == true)
        {
            UpdateCharacterSelectUI(4);
            BackgroundColorChanger(4);
        }
            
        PlayerTracker();
        SwitchScene();
        Debug.Log("Player Name: " + player1Wizard.name + "\nCurrent Animation: " + currentAnimation1);
    }
    /**
     *Adds all characters from the main Character list to the rest of the Player Character Lists
     */
    private void PopulateCharacterList()
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
    private void CountPlayers()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (ID == 4)
                return;
            else if(ID < 4)
                ID++;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Delete))
        {
            if (ID == 1)
                return;
            else if(ID > 1)
                ID--;
        }
             
    }
    /**
     * Changes the background color depending on the player
     */
    private void BackgroundColorChanger(int index)
    {
        switch(index)
        {
            case (1):
                player1Color.color = Color.Lerp(player1Color.color, player1CharacterColor, Time.deltaTime * BackgroundColorTransitionSpeed);
                break;
            case (2):
                player2Color.color = Color.Lerp(player2Color.color, player2CharacterColor, Time.deltaTime * BackgroundColorTransitionSpeed);
                break;
            case (3):
                player3Color.color = Color.Lerp(player3Color.color, player3CharacterColor, Time.deltaTime * BackgroundColorTransitionSpeed);
                break;
            case (4):
                player4Color.color = Color.Lerp(player4Color.color, player4CharacterColor, Time.deltaTime * BackgroundColorTransitionSpeed);
                break;

        }   
    }
    //Meant to store the information on multiple players
    private void PlayerTracker()
    {
        switch(ID)
        {
            case (1):
                Player1.GetComponent<PlayerController>().ID = ID;
                Player2.SetActive(false);
                Player3.SetActive(false);
                Player4.SetActive(false);
                playerCharacter = player1Index;
                break;
            case (2):
                Player2.AddComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(false);
                Player4.SetActive(false);
                playerCharacter = player2Index;
                break;
            case (3):
                Player3.AddComponent<PlayerController>().ID = ID;
                Player3.SetActive(true);
                Player4.SetActive(false);
                playerCharacter = player3Index;
                break;
            case (4):
                Player4.AddComponent<PlayerController>().ID = ID;
                Player4.SetActive(true);
                playerCharacter = player4Index;
                break;
        }
    }
    /**
     * Cycles forward in the list of the characters
     * toggles off the ready for the player to signify that they are not ready to choose a character
     */
    public void LeftArrow(int ID)
    {
        if(Input.GetKeyDown(KeyCode.Return))
            return;
        switch (ID)
        {
            case (1):
                player1Ready = false;
                player1Index--;
                if (player1Index < 0)
                    player1Index = player1CharacterList.Count - 1;
                break;
            case (2):
                player2Ready = false;
                player2Index--;
                if (player2Index < 0)
                    player2Index = player2CharacterList.Count - 1;
                break;
            case (3):
                player3Ready = false;
                player3Index--;
                if (player3Index < 0)
                    player3Index = player3CharacterList.Count - 1;
                break;
            case 4:
                player4Ready = false;
                player4Index--;
                if (player4Index < 0)
                    player4Index = player4CharacterList.Count - 1;
                break;
        }

        UpdateCharacterSelectUI(ID);

        arrowSFX.Play();
    }
    /**
     * Cycles forward in the list of the characters
     * toggles off the ready for the player to signify that they are not ready to choose a character
     */
    public void RightArrow(int ID)
    {
        if (Input.GetKeyDown(KeyCode.Return))
            return;
        switch(ID)
        {
            case (1):
                player1Ready = false;
                player1Index++;
                if (player1Index == player1CharacterList.Count)
                    player1Index = 0;
                break;
            case (2):
                player2Ready = false;
                player2Index++;
                if (player2Index == player2CharacterList.Count)
                    player2Index = 0;
                break;
            case (3):
                player3Ready = false;
                player3Index++;
                if (player3Index == player3CharacterList.Count)
                    player3Index = 0;
                break;
            case 4:
                player4Ready = false;
                player4Index++;
                if (player4Index == player4CharacterList.Count)
                    player4Index = 0;
                break;
        }

        UpdateCharacterSelectUI(ID);

        arrowSFX.Play();
    }

    public void Confirm(int ID)
    {
        if (Input.GetKeyDown(KeyCode.Return))
            return;
        switch (ID)
        {
            case (1):
                PlayerPrefs.SetInt("Player1", player1Index);
                player1Ready = true;
                break;
            case (2):
                PlayerPrefs.SetInt("Player2", player2Index);
                player2Ready = true;
                break;
            case (3):
                PlayerPrefs.SetInt("Player3", player3Index);
                player3Ready = true;
                break;
            case (4):
                PlayerPrefs.SetInt("Player4", player4Index);
                player4Ready = true;
                break;
        }

        confirmSFX.Play();
    }
    private void UpdateCharacterSelectUI(int player)
    {
        //Sets the Splash, Name, Color
        switch (player)
        {
            case (1):
                player1Wizard = player1CharacterList[player1Index].wizard;
                //currentAnimation1 = player1Wizard.name;
                //SetCharacterState(currentAnimation1);
                SetAnimation(player1Wizard, true, 1f);
                player1Name.text = player1CharacterList[player1Index].characterName;
                player1CharacterColor = player1CharacterList[player1Index].characterColor;

                break;
            case (2):
                player2Wizard = player2CharacterList[player2Index].wizard;
                //SetCharacterState(player, player1Index);
                player2Name.text = player2CharacterList[player2Index].characterName;
                player2CharacterColor = player2CharacterList[player2Index].characterColor;
                break;
            case (3):
                player3Wizard = player3CharacterList[player3Index].wizard;
                //SetCharacterState(player, player1Index);
                player3Name.text = player3CharacterList[player3Index].characterName;
                player3CharacterColor = player3CharacterList[player3Index].characterColor;
                break;
            case 4:
                player4Wizard = player4CharacterList[player4Index].wizard;
                //SetCharacterState(player, player1Index);
                player4Name.text = player4CharacterList[player4Index].characterName;
                player4CharacterColor = player4CharacterList[player4Index].characterColor;
                break;
        }
    }
    private void SetCharacterState(string state)
    {
        if (state.Equals("The boi_Idle"))
            SetAnimation(player1Wizard, false, 1f);
        else if (state.Equals("The boi_Walk"))
            SetAnimation(player1Wizard, true, 2f);
        else if (state.Equals("The boi_Cast_idle"))
            SetAnimation(player1Wizard, true, 3f);
    }

    private void SetAnimation(AnimationReferenceAsset wizard, bool loop, float timeS)
    {
        if (wizard.name.Equals(currentAnimation1))
            return;
        player1.state.SetAnimation(0, wizard, loop);
    }

    private void SwitchScene()
    {
        switch(ID)
        {
            case (2):
                if (player1Ready && player2Ready)
                {
                    SceneManager.LoadScene("Game_MJ_Test");
                    characterSelectMusic.Stop();
                } 
                break;
            case (3):
                if (player1Ready && player2Ready && player3Ready)
                {
                    SceneManager.LoadScene("Game_MJ_Test");
                    characterSelectMusic.Stop();
                }
                break;
            case (4):
                if (player1Ready && player2Ready && player3Ready && player4Ready)
                {
                    SceneManager.LoadScene("Game_MJ_Test");
                    characterSelectMusic.Stop();
                }
                break;
        }
    }
    [System.Serializable]
    public class CharacterSelectObject
    {
        public AnimationReferenceAsset wizard;
        public string characterName;
        public Color characterColor;
    }
}
