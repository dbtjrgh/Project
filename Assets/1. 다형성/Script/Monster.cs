using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IHitable
{
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;

    public GameObject bulletPrefab; // Bullet 프리팹
    public Transform shotPoint; // 총구(bullet을 생성할 위치를 참조하기 위한 gameobject의 Transform)

    public float shotInterval = 1f;

    private void Start()
    {
        StartCoroutine(ShotCoroutine());
    }
    public virtual void Hit(float damage)
    {
        currentHP -= damage;
        print($"{name} Take Damage : {damage}, current Hp : { currentHP } ");

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ShotCoroutine()
    {
        if (bulletPrefab == null || shotPoint == null)
        {
            yield break;
        }

        while(true)
        {
            Shot();

            yield return new WaitForSeconds(shotInterval);
        }
    }

    public void Shot()
    {
        // bullet 생성
        GameObject bulletObject = 
                Instantiate(bulletPrefab,shotPoint.position,shotPoint.rotation);

        // rigidbody 참조 및 Addforce를 통해 앞으로 날아가도록 함
        bulletObject.GetComponent<Rigidbody>().
            AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);

        // Bullet 참조 및 데미지 할당

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");
        

        // 3초후에 없어지기
        Destroy(bulletObject, 3f);
    }
}
