using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StarGameController : MonoBehaviour
{
    [Header("Game Sounds")]
    public AudioSource titleSong;
    // Start is called before the first frame update
    void Start()
    {
        titleSong.loop = true;
        titleSong.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelect");
    }
}
