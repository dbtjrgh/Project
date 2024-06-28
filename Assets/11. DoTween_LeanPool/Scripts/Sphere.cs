using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOPunchScale(new Vector3(.1f, .1f, .1f), .5f);
    }
}
