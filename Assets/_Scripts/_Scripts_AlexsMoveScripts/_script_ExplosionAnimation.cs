using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_ExplosionAnimation : MonoBehaviour
{
    public float delay = 0.5f;
    private Animator animate;
    public AudioSource bombExplode;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        animate.Play("explode");
        bombExplode.Play();
        Destroy(gameObject, animate.GetCurrentAnimatorStateInfo(0).length + delay);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
