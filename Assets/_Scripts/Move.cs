using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;

    private bool up = false, down = false, left = false, right = false;

    public SpriteRenderer SR;
    public ParticleSystem RedMag;
    public ParticleSystem GreenMag;
    public ParticleSystem BlueMag;
    public ParticleSystem WhiteMag;
    public Animator Walk;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
            Walk.SetBool("Walking", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
            Walk.SetBool("Walking", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            SR.flipX = false;
            Walk.SetBool("Walking", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            SR.flipX = true;
            Walk.SetBool("Walking", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            WhiteMag.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RedMag.Play();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            BlueMag.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GreenMag.Play();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            down = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            Walk.StopPlayback();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            WhiteMag.Clear();
            WhiteMag.Pause();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RedMag.Clear();
            RedMag.Pause();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            BlueMag.Clear();
            BlueMag.Pause();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GreenMag.Clear();
            GreenMag.Pause();
        }

        if (up)
        {
            transform.Translate(0, speed, 0);
        }
        if (down)
        {
            transform.Translate(0, -speed, 0);
        }
        if (right)
        {
            transform.Translate(speed, 0, 0);
           
        }
        if (left)
        {
            transform.Translate(-speed, 0, 0);
        }
        if(!up && !down && !left && !right)
        {
            Walk.SetBool("Walking", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           // transform.Translate(0, 1, 0);
        }
    }
}
