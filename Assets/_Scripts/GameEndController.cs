using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    [Header("Player Information")]
    public GameObject winningPlayer;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        winner();
    }
    private void winner()
    {

    }
    /**
     * Sends Players back to Player Select Screen
     */
    public void switchScene()
    {
        SceneManager.LoadScene("Player Select");
    }

}
