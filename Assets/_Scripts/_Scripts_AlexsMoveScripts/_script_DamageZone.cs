using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_DamageZone : MonoBehaviour
{
    public float DamagePerCheck = 10.0f;
    public bool OverrideSizeSettings = false;
    public float Scale = 1.0f;
    public float Lifetime = 2.0f;
    public int PlayerID;

    private float Timer = 0.0f;
    public Player owner;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        if (!OverrideSizeSettings)
        {
            this.transform.localScale *= Scale;
        }
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)(gameObject.transform.position.y * 10);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > Lifetime)
        {
            Deteriorate();
        }
    }


    void Deteriorate()
    {
        Destroy(this.gameObject);
    }


    public void ReportPoint()
    {
        owner.IncreaseScore();
    }

    public void ReportDamage(float dam)
    {
        owner.damageDone += dam;
    }

}
