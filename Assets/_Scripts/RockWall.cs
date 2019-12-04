using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)(gameObject.transform.position.y * 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
