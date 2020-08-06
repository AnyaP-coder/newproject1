using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //main
    public float speedMove;
    

    //gameplay 
    private float gravityForce;
    private Vector3 moveVector;
  


     
    public bool IsGround;

    //component links
    private CharacterController ch_controller;


    void Start()
    { 
        ch_controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        CharacterMove();
        
    }

    //movement method
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;




        
        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        ch_controller.Move(moveVector * Time.deltaTime);


        
    }

    

    }


