using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButtonQueue : MonoBehaviour
{
    public GameObject colorChangingObject; 

    private Queue<Color> colorQueue = new Queue<Color>();
    void Start()
    {
        StartCoroutine(ProcessQueue());
    }

    IEnumerator ProcessQueue()
    {
        while (true)
        {
            if (colorQueue.Count > 0)
            {
                Color color = colorQueue.Dequeue();
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

    public void EnqueueColor(Color color)
    {
        colorQueue.Enqueue(color);
    }

    public void EnqueueRed()
    {
        EnqueueColor(Color.red);
    }

    public void EnqueueBlue()
    {
        EnqueueColor(Color.blue);
    }

    public void EnqueueGreen()
    {
        EnqueueColor(Color.green);
    }
}
