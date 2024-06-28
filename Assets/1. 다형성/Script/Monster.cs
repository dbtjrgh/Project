using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IHitable
{
    public string monsterName;
    public float maxHP;
    public float currentHP;
    public float damage;

    public GameObject bulletPrefab; // Bullet ������
    public Transform shotPoint; // �ѱ�(bullet�� ������ ��ġ�� �����ϱ� ���� gameobject�� Transform)

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
        // bullet ����
        GameObject bulletObject = 
                Instantiate(bulletPrefab,shotPoint.position,shotPoint.rotation);

        // rigidbody ���� �� Addforce�� ���� ������ ���ư����� ��
        bulletObject.GetComponent<Rigidbody>().
            AddForce(bulletObject.transform.forward * 10f, ForceMode.Impulse);

        // Bullet ���� �� ������ �Ҵ�

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.targetLayer = 1 << LayerMask.NameToLayer("Player");
        

        // 3���Ŀ� ��������
        Destroy(bulletObject, 3f);
    }
}
