using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int PlayerID;
    public Player owner;

    public float damage;
    public float knockback;

    private void Awake()
    {
        owner = transform.root.GetComponent<Player>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //owner = gameObject.GetComponentInParent<Player>();
        AssignID(owner.ID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignID(int ID)
    {
        PlayerID = ID;
    }

    public int CheckID()
    {
        return PlayerID;
    }

    public void ReportPoint()
    {
        owner.IncreaseScore();
    }
}
