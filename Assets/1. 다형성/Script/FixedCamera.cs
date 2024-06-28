using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    public Transform playerTransform; 
    public Vector3 offset; 
    public Quaternion fixedRotation; 

    void Start()
    {
        transform.rotation = fixedRotation;
    }

    void Update()
    {
        Vector3 targetPosition = playerTransform.position + offset;

        transform.position = targetPosition;
    }
}
