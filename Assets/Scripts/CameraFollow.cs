using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float smoothSpeed = 0.125f;


    //Using fixedupdate for better camera follow
    void FixedUpdate()
    {
        Vector3 desiredPosisiton = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosisiton, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
