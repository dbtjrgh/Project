using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;

    private void OnTriggerEnter(Collider other)
    {
        // 트리거 안에 들어온 다른 객체의 Layer가 targetLayer와 다른 레이어면 무시
        
        // 
        if ((targetLayer | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }

        // interface를 활용한 방법
        if (other.TryGetComponent<IHitable > (out IHitable hitable))
        {
            hitable.Hit(damage);
        }

        // 유니티스러운 속도를 위한 SendMessage를 활용한 다른 방법    
        //other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }
}
