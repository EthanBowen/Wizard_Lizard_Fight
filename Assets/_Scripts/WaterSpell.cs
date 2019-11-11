using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpell : MonoBehaviour
{
    public float x = 0, y = 0;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.rotation.x;
        y = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x * 100, y * 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() == null || collision.gameObject.GetComponent<Player>().ID != gameObject.GetComponent<PlayerAttack>().CheckID())
        {
            Destroy(gameObject);
        }
        
    }
}
