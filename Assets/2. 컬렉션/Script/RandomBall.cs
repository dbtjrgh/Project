using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RandomBall : MonoBehaviour
{
    public GameObject ball;
    private List<Vector3> Vector3List = new List<Vector3>();
    private List<Color> ColorList = new List<Color>();

    


    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 random = new Vector3(Random.Range(-8.0f, 8.0f), 1.0f, Random.Range(-8.0f, 8.0f));
            Vector3List.Add(random);
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            ColorList.Add(randomColor);
        }
        StartCoroutine(MoveAndColorBall());
    }

    private IEnumerator<WaitForSeconds> MoveAndColorBall()
    {
        Renderer renderer = ball.GetComponent<Renderer>();

        for (int i = 0; i < Vector3List.Count; i++)
        {
            ball.transform.position = Vector3List[i];
            Debug.Log("Object moved to: " + Vector3List[i]);

            renderer.material.color = ColorList[i];
            Debug.Log("Object color changed to: " + ColorList[i]);

            yield return new WaitForSeconds(1f);
        }


    }


}
