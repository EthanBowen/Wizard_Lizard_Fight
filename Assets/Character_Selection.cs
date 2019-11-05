using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Selection : MonoBehaviour
{

    public Texture2D[] list;
    // Start is called before the first frame update
    void Start()
    { 
        list[1] = Resources.Load<Texture2D>("Secret_Wizard 1");
        list[0] = Resources.Load<Texture2D>("Salamander 1");
    }
}
