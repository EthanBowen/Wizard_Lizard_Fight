using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_KnockbackTrigger : MonoBehaviour
{
    public float Knockback = 1.0f;
    public float Damage = 400f;
    public Player owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && player.ID != owner.ID)
        {
            Vector2 difference = player.transform.position - transform.position;
            difference = difference.normalized * Knockback * 100;
            Debug.Log("Applying knockback to player: " + player.ID + " with vector: " + difference);
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
        }
    }


    public void ReportPoint()
    {
        owner.IncreaseScore();
    }
}
