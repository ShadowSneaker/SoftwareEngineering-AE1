using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The direction the player should move in.
    private Vector3 MoveDir;
    
    
    
    // A reference to the attached PlayerScript component.
    PlayerScript Player;




    private void Start()
    {
        Player = GetComponent<PlayerScript>();
    }


    private void FixedUpdate()
    {
        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        MoveDir = transform.TransformDirection(MoveDir);

        if (Input.GetButton("Jump"))
        {
            Player.Jump();
        }

        Player.MoveDirection(MoveDir);
    }

}
