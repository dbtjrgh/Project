using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{

    public Transform[] hands;
    private Weapon[] weapons = new Weapon[2];
    private GameObject[] weaponObjs = new GameObject[2];

    public void EquipWeapon(int index, Weapon weapon)
    {

        if (index > weapons.Length) return;

        weapons[index] = weapon;

        //착용하고 있던 아이템이 있다면
        if (weaponObjs[index] != null)
        {
            Destroy(weaponObjs[index]);
            weaponObjs[index] = null;
        }

        //매개변수 weapon이 null이 아니면
        if (weapon != null)
        { //무기 오브젝트 생성

            //var someWeapon = Instantiate(weapon.equipPrefab);
            //someWeapon.transform.SetParent(hands[index]);
            //someWeapon.transform.localPosition = Vector3.zero;

            weaponObjs[index] = Instantiate(weapon.equipPrefab, hands[index]);
        }
    }
}
