using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    private void Update()
    {
        //setSize(player.health);
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(player.health, 1f);
    }
    /*
    public void setSize(float sizeNormalized)
    {
        float hp = sizeNormalized / sizeNormalized;
        bar.localScale = new Vector3(hp, 1f);
    }
    */
}
