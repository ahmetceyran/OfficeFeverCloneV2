using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private GameObject collectPoint;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;

    //Player movement using joystick
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(joystick.Horizontal * moveSpeed, 0, joystick.Vertical * moveSpeed);
        controller.Move(direction);


        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetBool("kosuyor" , true);
            if(collectPoint.transform.childCount >= 1)
            {
                animator.SetBool("tasiyor" , true);
            }
        }
        else
        {
            animator.SetBool("kosuyor" , false);
            animator.SetBool("tasiyor" , true);
            if(collectPoint.transform.childCount <= 0)
            {
                animator.SetBool("tasiyor" , false);
            }
        }
    }

    
    /*[SerializeField] private Rigidbody rigi;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;

    //Player movement using joystick
    void FixedUpdate()
    {
        rigi.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigi.velocity.y, joystick.Vertical * moveSpeed);

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigi.velocity);
        }
    }*/
}
