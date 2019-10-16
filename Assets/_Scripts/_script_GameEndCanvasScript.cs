using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _script_GameEndCanvasScript : MonoBehaviour
{
    int winner;
    public Text instruction;
    // Start is called before the first frame update
    void Start()
    {
        winner = 0;
        winner = PlayerPrefs.GetInt("winner");

        instruction = GetComponent<Text>();

        instruction.text = "WINNER: " + winner + "\n Press space to restart";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
