using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    public int ID;
    [Header("Player Information")]
    public GameObject winningPlayer;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    [Header("Player Stats")]
    public TextMeshProUGUI playerWinner;
    public TextMeshProUGUI player1Stats;
    public TextMeshProUGUI player2Stats;
    public TextMeshProUGUI player3Stats;
    public TextMeshProUGUI player4Stats;

    [Header("Music and Sounds")]
    [SerializeField] private AudioSource endMusic;
    [SerializeField] private AudioSource restart;

    private int killCountPlaceHold = 0;
    private int damageDonePlaceHold = 0;
    private int damageTakenPlaceHold = 0;

    // Start is called before the first frame update
    void Start()
    {
        endMusic.loop = true;
        endMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        activePlayers();
        winner();
    }
    /**
     * Update who is the winner based off the game
     */
    private void winner()
    {
        playerWinner.text = "Player "  + PlayerPrefs.GetInt("winner").ToString() + "\n Ruled Supreme";
    }
    /**
     * Sends Players back to Player Select Screen
     */
    public void switchScene()
    {
        restart.Play();
        SceneManager.LoadScene("PlayerSelect");
        endMusic.Stop();
    }
    /**
     * Update the players Stat to show to all
     */
    private void playerStats(int active)
    {
        switch(active)
        {
            case (1):
                player1Stats.text = "Kill Count: \n" + PlayerPrefs.GetInt("P1_Kills").ToString() + "\nDamage Done:\n" + PlayerPrefs.GetFloat("P1_DamageDone").ToString() + "\nDamage Taken:\n" + PlayerPrefs.GetFloat("P1_DamageTaken").ToString();
                break;
            case (2):
                player2Stats.text = "Kill Count: \n" + PlayerPrefs.GetInt("P2_Kills").ToString() + "\nDamage Done:\n" + PlayerPrefs.GetFloat("P2_DamageDone").ToString() + "\nDamage Taken:\n" + PlayerPrefs.GetFloat("P2_DamageTaken").ToString();
                break;
            case (3):
                player3Stats.text = "Kill Count: \n" + PlayerPrefs.GetInt("P3_Kills").ToString() + "\nDamage Done:\n" + PlayerPrefs.GetFloat("P3_DamageDone").ToString() + "\nDamage Taken:\n" + PlayerPrefs.GetFloat("P3_DamageTaken").ToString();
                break;
            case (4):
                player4Stats.text = "Kill Count: \n" + PlayerPrefs.GetInt("P4_Kills").ToString() + "\nDamage Done:\n" + PlayerPrefs.GetFloat("P4_DamageDone").ToString() + "\nDamage Taken:\n" + PlayerPrefs.GetFloat("P4_DamageTaken").ToString();
                break;
        }      
    }
    /**
     * shows the players that are active stats'
     */
    private void activePlayers()
    {
        switch(ID)
        {
            case(2):
                player2.SetActive(true);
                player3.SetActive(false);
                player4.SetActive(false);
                playerStats(1);
                playerStats(2);
                break;
            case (3):
                player3.SetActive(true);
                player4.SetActive(false);
                playerStats(1);
                playerStats(2);
                playerStats(3);
                break;
            case (4):
                player4.SetActive(true);
                playerStats(1);
                playerStats(2);
                playerStats(3);
                playerStats(4);
                break;
        }
    }
}
