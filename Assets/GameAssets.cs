using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
   //THIS WAS CREATED TO GRAB THE DAMAGE DISPLAY DAMAGE
    private static GameAssets _i;

    

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    public Transform playerDamagePopup;
}
