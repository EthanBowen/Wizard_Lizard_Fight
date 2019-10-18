using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class _script_DisableSpriteDuringGameplay : MonoBehaviour
{
    public bool HideDuringGameplay = true;
    public bool HideInDebugMode = false;

    private SpriteRenderer objectSprite;
    // Awake is called before Start()
    private void Awake()
    {
        objectSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (objectSprite != null)
        {
            if (HideDuringGameplay)
            {
                objectSprite.enabled = false;
            }
            else
            {
                objectSprite.enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void event_DebugMode(bool state)
    {
        if (objectSprite != null)
        {
            if (!HideInDebugMode)
            {
                objectSprite.enabled = state;
            }
            else
            {
                objectSprite.enabled = false;
            }
        }
    }
}
