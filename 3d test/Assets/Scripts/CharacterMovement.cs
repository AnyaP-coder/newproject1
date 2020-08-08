using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController cc;
    Vector3 moveVec, gravity;

    float speed = 8, jumpSpeed = 12;

    int laneNumber = 1;
  

    void Start()
    {
        cc = GetComponent<CharacterController>();
        moveVec = new Vector3(1, 0, 0);
        gravity = Vector3.zero;
    }


    void Update()
    {
        if (cc.isGrounded)
        {
            gravity = Vector3.zero;

            if (Input.GetAxisRaw("Vertical") > 0)
                gravity.y = jumpSpeed;
        }
        else
            gravity += Physics.gravity * Time.deltaTime * 3;




        moveVec.x = speed;
        moveVec += gravity;
        moveVec *= Time.deltaTime;


        float input = Input.GetAxis("Horizontal");
        if (Mathf.Abs(input) > .1f)
        {
            laneNumber += (int)Mathf.Sign(input);
            laneNumber = Mathf.Clamp(laneNumber, 0, 2);
        }

        cc.Move(moveVec);


    }
}
 


