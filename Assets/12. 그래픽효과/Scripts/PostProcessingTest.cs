using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingTest : MonoBehaviour
{
    public PostProcessVolume volume;

    [Range(0,1)]
    public float caIntencity = 0;

    ChromaticAberration ca;

    private void Start()
    {
        if(volume.profile.TryGetSettings(out ca))
        {
            print("색 수차 세팅 존재함");
        }
        else
        {
            print("색 수차 세팅 참조 실패");
        }
    }

    private void Update()
    {
        if(ca == null)
        {
            return;
        }
        ca.intensity.value = caIntencity;
    }

}
