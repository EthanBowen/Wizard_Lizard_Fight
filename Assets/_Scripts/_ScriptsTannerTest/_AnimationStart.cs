using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class _AnimationStart : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, walking;
    public string currentState;
    public float movement;
    public float speed;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentState = "Idle";
        setCharacterState(currentState);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //sets character animation
    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }

    public void setCharacterState(string state)
    {
        if (state.Equals("Idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        else if (state.Equals("Walking")) 
        {
            SetAnimation(walking, true, 1f);
        }
    }

    public void Move()
    {
        movement = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
        if (movement != 0)
        {
            setCharacterState("Walking");
        }
        else
        {
            setCharacterState("Idle");
        }

    }
}
