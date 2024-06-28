using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayer : MonoBehaviour
{
    public Gun[] guns; // �� �迭
    private int currentGun = 0; // ���� �������� ���� Index
    public TargetFollower subHandTarget; // Two Bone IK�� Target�� ����ٴ� ���
    public TargetFollower subHandHint; // Two Bone IK�� Hint�� ����ٴ� ���

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            // �ǹ�ư�� ���������� ����
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
