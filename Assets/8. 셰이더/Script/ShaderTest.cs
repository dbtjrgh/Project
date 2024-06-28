using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTest : MonoBehaviour
{
    Renderer render;

    [Range(0, 1)]
    public float colorAmount;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        render.material.SetFloat("_colorAmount", colorAmount);

        render.material.SetColor("_MainTex", Color.white);
    }
}