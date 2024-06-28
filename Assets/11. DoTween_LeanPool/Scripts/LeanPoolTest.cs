using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class LeanPoolTest : MonoBehaviour
{
    public GameObject prefab;

    // 버튼에서 호출해줄 함수
    public void SpawnSphere()
    {
        GameObject obj = LeanPool.Spawn(prefab, Random.insideUnitSphere * 5, Quaternion.identity);

        LeanPool.Despawn(obj, Random.Range(2f, 5f));
    }
}
