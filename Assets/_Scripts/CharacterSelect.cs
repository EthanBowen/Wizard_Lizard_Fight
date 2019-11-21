using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Spine.Unity;
using System;



/*
 * MJ:
 * This may help in picking a skin. Usage:
 * 
 * SelectedSkin skin = SelectedSkin.C4;
 * ......
 * [Change skins]
 * skin = SelectedSkin.Mancer;
 * ......
 * [Check current skin]
 * if (skin = SelectedSkin.Ax) {
 *      // code
 * }
 */
public enum SelectedSkin
{
    Mancer,
    Ax,
    C4,
    Lizard
}


public class CharacterSelect : MonoBehaviour
{
    //player ID
    public int ID = 2;

    //Player panels
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    private Dictionary<int, GameObject> Players;

    //public bool player1Ready;
    //public bool player2Ready;
    //public bool player3Ready;
    //public bool player4Ready;
    private Dictionary<int, bool> playerReady;

    private int playerCharacter;

    //to track the players choice for character
    //public int player1Index;
    //public int player2Index;
    //public int player3Index;
    //public int player4Index;
    private Dictionary<int, int> playerIndex;

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
     private Dictionary<int, List<CharacterSelectObject>> masterList;

    public int characterListCount;

    [Header("UI Reference")]

     public TextMeshProUGUI player1Name;
     public TextMeshProUGUI player2Name;
     public TextMeshProUGUI player3Name;
     public TextMeshProUGUI player4Name;
     private Dictionary<int, TextMeshProUGUI> nameList;

     public Animator player1;
     //public AnimationReferenceAsset player1Wizard;
     public Animator player2;
     //public AnimationReferenceAsset player2Wizard;
     public Animator player3;
     //public AnimationReferenceAsset player3Wizard;
     public Animator player4;
    //public AnimationReferenceAsset player4Wizard;
     private Dictionary<int, Animator> animatorList;

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

    public SelectedSkin selectedSkin = SelectedSkin.Mancer;
    private int old_ID;

    private void Start()
    {
        PopulateCharacterList();

        masterList = new Dictionary<int, List<CharacterSelectObject>>();
        masterList.Add(1, player1CharacterList);
        masterList.Add(2, player2CharacterList);
        masterList.Add(3, player3CharacterList);
        masterList.Add(4, player4CharacterList);
        
        playerReady = new Dictionary<int, bool>();
        playerReady.Add(1, false);
        playerReady.Add(2, false);
        playerReady.Add(3, false);
        playerReady.Add(4, false);

        playerIndex = new Dictionary<int, int>();
        playerIndex.Add(1, 0);
        playerIndex.Add(2, 0);
        playerIndex.Add(3, 0);
        playerIndex.Add(4, 0);

        animatorList = new Dictionary<int, Animator>();
        animatorList.Add(1, player1);
        animatorList.Add(2, player2);
        animatorList.Add(3, player3);
        animatorList.Add(4, player4);

        Players = new Dictionary<int, GameObject>();
        Players.Add(1, Player1);
        Players.Add(2, Player2);
        Players.Add(3, Player3);
        Players.Add(4, Player4);

        nameList = new Dictionary<int, TextMeshProUGUI>();
        nameList.Add(1, player1Name);
        nameList.Add(2, player2Name);
        nameList.Add(3, player3Name);
        nameList.Add(4, player4Name);

        player1CharacterColor = characterList[0].characterColor;
        nameList[1].text = characterList[0].characterName;
        player2CharacterColor = characterList[1].characterColor;
        nameList[2].text = characterList[1].characterName;
        player3CharacterColor = characterList[2].characterColor;
        nameList[3].text = characterList[2].characterName;
        player4CharacterColor = characterList[3].characterColor;
        nameList[4].text = characterList[3].characterName;

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
            
        ActivatesPlayers();
        SwitchScene();

        PlayerPrefs.SetInt("NumberOfPlayers", ID);
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
            if (ID == 2)
                return;
            else if(ID > 2)
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
    private void ActivatesPlayers()
    {
        switch (ID)
        {
            case (1):
                Player1.GetComponent<PlayerController>().ID = ID;
                Player2.SetActive(false);
                Player3.SetActive(false);
                Player4.SetActive(false);
                playerCharacter = playerIndex[ID];
                break;
            case (2):
                Player2.GetComponent<PlayerController>().ID = ID;
                Player2.SetActive(true);
                Player3.SetActive(false);
                Player4.SetActive(false);
                playerCharacter = playerIndex[ID];
                break;
            case (3):
                Player3.GetComponent<PlayerController>().ID = ID;
                Player3.SetActive(true);
                Player4.SetActive(false);
                playerCharacter = playerIndex[ID];
                break;
            case (4):
                Player4.GetComponent<PlayerController>().ID = ID;
                Player4.SetActive(true);
                playerCharacter = playerIndex[ID];
                break;
        }
    }
    /**
     * Cycles forward in the list of the characters
     * toggles off the ready for the player to signify that they are not ready to choose a character
     */
    public void LeftArrow(int id)
    {
        if(Input.GetKeyDown(KeyCode.Return))
            return;
       
        if(playerReady[id])
        {
            playerReady[id] = false;
            UpdatePlayerSelect(playerIndex[id], false);
        }
        playerIndex[id]--;

        if (playerIndex[id] < 0)
            playerIndex[id] = masterList[id].Count - 1;

        UpdateCharacterSelectUI(id);

        arrowSFX.Play();
    }
    /**
     * Cycles forward in the list of the characters
     * toggles off the ready for the player to signify that they are not ready to choose a character
     */
    public void RightArrow(int id)
    {
        if (Input.GetKeyDown(KeyCode.Return))
            return;
        
        if (playerReady[id])
        {
            playerReady[id] = false;
            UpdatePlayerSelect(playerIndex[id], false);
        }
        playerIndex[id]++;

        if (playerIndex[id] == masterList[id].Count)
            playerIndex[id] = 0;

        UpdateCharacterSelectUI(id);

        arrowSFX.Play();
    }

    public void Confirm(int id)
    {

        if (!CharacterSelected(id))
        {
            PlayerPrefs.SetInt("Player" + id, playerIndex[id]);
            playerReady[id] = true;

            UpdatePlayerSelect(playerIndex[id], true);

            confirmSFX.Play();
        }
    }
    private void UpdateCharacterSelectUI(int player)
    {
        //Sets the Splash, Name, Color
        
        SetCharacterAnimation(animatorList[player], masterList[player], playerIndex[player]);
        nameList[player].text = masterList[player][playerIndex[player]].characterName;
        Color tempColor = animatorList[player].GetComponent<SpriteRenderer>().color;
        if (CharacterSelected(player) && !playerReady[player])
        {
            animatorList[player].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, 0.3f);
        }
        else
        {
            animatorList[player].GetComponent<SpriteRenderer>().color = new Color(tempColor.r, tempColor.g, tempColor.b, 1);
        }
    }

    private void SetCharacterAnimation(Animator player, List<CharacterSelectObject> list, int index)
    {
        if (player.runtimeAnimatorController == list[index].graphicWizard)
            return;
        RuntimeAnimatorController skele = list[index].graphicWizard;
        player.runtimeAnimatorController = skele;
    }

    private void SwitchScene()
    {
        switch(ID)
        {
            case (2):
                if (playerReady[1] && playerReady[2])
                {
                    SceneManager.LoadScene("Game");
                    characterSelectMusic.Stop();
                } 
                break;
            case (3):
                if (playerReady[1] && playerReady[2] && playerReady[3])
                {
                    SceneManager.LoadScene("Game");
                    characterSelectMusic.Stop();
                }
                break;
            case (4):
                if (playerReady[1] && playerReady[2] && playerReady[3] && playerReady[4])
                {
                    SceneManager.LoadScene("Game");
                    characterSelectMusic.Stop();
                }
                break;
        }
    }

    private void UpdatePlayerSelect(int index, bool b)
    {
        masterList[1][index].selected = b;
        masterList[2][index].selected = b;
        masterList[3][index].selected = b;
        masterList[4][index].selected = b;
    }

    private bool CharacterSelected(int player)
    {
        return masterList[1][playerIndex[player]].selected
            || masterList[2][playerIndex[player]].selected
            || masterList[3][playerIndex[player]].selected
            || masterList[4][playerIndex[player]].selected;
    }
    

    [System.Serializable]
    public class CharacterSelectObject
    {
        public bool selected;
        public RuntimeAnimatorController graphicWizard;
        public string characterName;
        public Color characterColor;
    }
}
