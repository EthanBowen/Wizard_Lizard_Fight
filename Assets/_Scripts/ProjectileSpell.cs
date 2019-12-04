using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : MonoBehaviour
{
    public float x = 0, y = 0;
    public bool collisions;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.rotation.x;
        y = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)(gameObject.transform.position.y * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Water Collision");
        if(collisions 
            && (collision.gameObject.GetComponent<Player>() == null 
            || collision.gameObject.GetComponent<Player>().ID != gameObject.GetComponent<PlayerAttack>().CheckID()))
        {
            if (collision.gameObject.GetComponent<PlayerAttack>() == null
            || collision.gameObject.GetComponent<PlayerAttack>().CheckID() != gameObject.GetComponent<PlayerAttack>().CheckID())
                Destroy(gameObject);
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisions
            && (collision.gameObject.GetComponent<Player>() == null
            || collision.gameObject.GetComponent<Player>().ID != gameObject.GetComponent<PlayerAttack>().CheckID()))
        {
            if ((collision.gameObject.GetComponent<PlayerAttack>() == null
            || collision.gameObject.GetComponent<PlayerAttack>().CheckID() != gameObject.GetComponent<PlayerAttack>().CheckID())
            && (collision.gameObject.GetComponent<Tower>() == null || !collision.isTrigger))
                Destroy(gameObject);
        }
    }
}
