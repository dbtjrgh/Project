using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButtonStack : MonoBehaviour
{
    public GameObject colorChangingObject; 

    private Stack<Color> colorStack = new Stack<Color>(); 

    void Start()
    {
        StartCoroutine(ProcessStack());
    }

    IEnumerator ProcessStack()
    {
        while (true)
        {
            if (colorStack.Count > 0)
            {
                Color color = colorStack.Pop();
                ApplyColor(color);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void ApplyColor(Color color)
    {
        Vector3 randomPosition = new Vector3(Random.Range(300.0f, 1300.0f), Random.Range(100.0f, 400.0f), Random.Range(-300.0f, 0.0f));
        colorChangingObject.transform.position = randomPosition;

        Renderer cubeRenderer = colorChangingObject.GetComponent<Renderer>();
        cubeRenderer.material.color = color;
    }

    public void PushColor(Color color)
    {
        colorStack.Push(color);
    }

    public void PushRed()
    {
        PushColor(Color.red);
    }

    public void PushBlue()
    {
        PushColor(Color.blue);
    }

    public void PushGreen()
    {
        PushColor(Color.green);
    }
}
