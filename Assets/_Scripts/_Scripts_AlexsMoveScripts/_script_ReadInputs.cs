using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _script_ReadInputs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float P1_move_horiz, P1_move_vert;
    float P2_move_horiz, P2_move_vert;
    float P3_move_horiz, P3_move_vert;
    float P4_move_horiz, P4_move_vert;

    // Update is called once per frame
    void Update()
    {
        P1_move_horiz = Input.GetAxisRaw("P1_horiz_left");
        P1_move_vert = Input.GetAxisRaw("P1_vert_left");
        P2_move_horiz = Input.GetAxisRaw("P1_horiz_left");
        P2_move_vert = Input.GetAxisRaw("P1_vert_left");
        P3_move_horiz = Input.GetAxisRaw("P1_horiz_left");
        P3_move_vert = Input.GetAxisRaw("P1_vert_left");
        P4_move_horiz = Input.GetAxisRaw("P1_horiz_left");
        P4_move_vert = Input.GetAxisRaw("P1_vert_left");
    }
}
