using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDamage : MonoBehaviour
{
    private TextMeshPro tm;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private const float DISAPPEAR_TIMER_MAX = .5f;
    private static int sortingOrder;

    public static DisplayDamage Create(Vector3 position, int damageAmount)
    { 
        //sets the position of the damage text 
        Transform damageTransform = Instantiate(GameAssets.i.playerDamagePopup, position, Quaternion.identity);

        DisplayDamage displayDamage = damageTransform.GetComponent<DisplayDamage>();
        displayDamage.Setup(damageAmount);

        return displayDamage;
    }
    
    private void Awake()
    {
        tm = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(float damageAmount)
    {
        //sets damage text
        tm.SetText(damageAmount.ToString());
        //changes color of damage text
        textColor = tm.color;
        //sets the timer to deswpan the damage text
        disappearTimer = DISAPPEAR_TIMER_MAX;
        //for effects of damage text moving
        moveVector = new Vector3(.7f, 1) * 30f;
        //places the text to be above each that is spawned
        sortingOrder++;
        //sets the text sorting order
        tm.sortingOrder = sortingOrder;
    }
    
    private void Update()
    {
        //moves the damage up and to the right
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 30f * Time.deltaTime;

        //increases the size of the damage text
        /*if(disappearTimer > DISAPPEAR_TIMER_MAX *.5f)
         {
             float increaseScaleAmount = .5f;
             transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
         }
         //decreases the size of the damage text
        */ if(disappearTimer < DISAPPEAR_TIMER_MAX * .5f)
         {
            float decreaseScaleAmount = .5f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        //slowly fades away damage text
        if(disappearTimer < 0)
        {
            //how fast the damage text disappears
            float disappearSpeed = 30f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            tm.color = textColor;
            if (textColor.a < 0)
                Destroy(gameObject);
        }
    }
    
}
