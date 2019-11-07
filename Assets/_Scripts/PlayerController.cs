using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player ID")]
    public int ID;
    public GameObject playerNumber;

    public int selectedIndex;
    public int characterListCount;

    private CharacterSelect character;

    private void Start()
    {
        characterListCount = 3;
    }

    private void Update()
    {

        //if (isActive(playerNumber))
            //return;
            //playerNumber.GetComponent<PlayerController>().ID = character.GetComponent<CharacterSelect>().ID;

    }
    public void leftArrow()
    {
       

        character.GetComponent<CharacterSelect>().selectedCharacterIndex--;
        if (selectedIndex < 0)
        {
            character.GetComponent<CharacterSelect>().selectedCharacterIndex = character.GetComponent<CharacterSelect>().characterList.Count - 1;
        }


        character.GetComponent<CharacterSelect>().updateCharacterSelectUI();
        /*
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
        */
    }

    public void rightArrow()
    {
        selectedIndex++;
        if(selectedIndex < characterListCount)
            character.GetComponent<CharacterSelect>().selectedCharacterIndex = selectedIndex;

        if (selectedIndex == characterListCount)
            selectedIndex = 0;

        character.gameObject.GetComponent<CharacterSelect>().selectedCharacterIndex = selectedIndex;
        character.gameObject.GetComponent<CharacterSelect>().updateCharacterSelectUI();
        /*
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = arrowSFX;
        audio.Play();
        */
    }

    private bool isActive(GameObject player)
    {
        bool activated = player.activeSelf;
        if (activated)
            return true;
        return false;
    }
}
