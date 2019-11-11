using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_ExplosionAnimation : MonoBehaviour
{
    public float delay = 0.5f;
    private Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        animate.Play("explode");
        Destroy(gameObject, animate.GetCurrentAnimatorStateInfo(0).length + delay);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
