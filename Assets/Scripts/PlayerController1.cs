using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] private Rigidbody rigi;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;

    //Player movement using joystick
    void FixedUpdate()
    {
        rigi.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigi.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigi.velocity);
        }
    }
}
