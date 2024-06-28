using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster
{
    public string oRcPassive = "오크는 데미지를 10% 덜 받습니다.";

    private void Start()
    {
        maxHP = currentHP = 150;
    }

    // 오크 패시브 활성화 오버라이드와 가상함수 이용
    public override void Hit(float damage)
    {
        damage *= 0.9f;

        base.Hit(damage);
    }
}
