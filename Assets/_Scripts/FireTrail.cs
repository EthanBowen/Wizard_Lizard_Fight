using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrail : MonoBehaviour
{
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time++;

        if(time >= 200)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnParticleSystemStopped()
    {
        
    }
}
