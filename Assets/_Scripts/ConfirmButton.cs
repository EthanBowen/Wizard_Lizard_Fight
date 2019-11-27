using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public CharacterSelect charSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(int character)
    {
        if(!charSelect.CharacterSelected(character))
        {
            gameObject.SetActive(false);
        }
    }
}
