using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayer : MonoBehaviour
{
    public Gun[] guns; // 총 배열
    private int currentGun = 0; // 현재 장착중인 총의 Index
    public TargetFollower subHandTarget; // Two Bone IK의 Target이 따라다닐 대상
    public TargetFollower subHandHint; // Two Bone IK의 Hint가 따라다닐 대상

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            // 탭버튼을 누를때마다 수행
            if(currentGun == 0)
            {
                ChangeWeapon(1);
            }
            else if (currentGun == 1) 
            {
                ChangeWeapon(0);
            }
            else
            {
                ChangeWeapon(2);
            }

            // ChangeWeapon(currentGun == 0 ? 1 : 0);

        }
    }

    public void ChangeWeapon(int index)
    {
        guns[currentGun].gameObject.SetActive(false);

        currentGun = index;

        guns[currentGun].gameObject.SetActive(true);

        subHandTarget.target = guns[currentGun].subHandTarget;
        subHandHint.target = guns[currentGun].subHandHint;
            
        
    }

}
