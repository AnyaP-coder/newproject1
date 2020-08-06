using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;

    private float verticalVelocity;
    private float gravity = 40.0f;
    private float jumpForce = 35.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (controller.isGrounded)

        {

           //verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
            
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical");
        controller.Move(moveVector * Time.deltaTime);
        /*Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);*/
    }
}

