using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int PlayerID;
    private Player owner;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        if (owner == null) 
            owner = gameObject.GetComponentInParent<Player>();
        if (owner != null)
        {
            PlayerID = owner.ID;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignID(int ID)
    {
        PlayerID = ID;
    }

    public void SetOwner(Player owner)
    {
        this.owner = owner;
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
