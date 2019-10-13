using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int PlayerID;
    private Player owner;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        owner = gameObject.GetComponentInParent<Player>();
        PlayerID = owner.ID;
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
        
    }
}
