using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if(target != null)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
}
