using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Monster
{
    public string oRcPassive = "��ũ�� �������� 10% �� �޽��ϴ�.";

    private void Start()
    {
        maxHP = currentHP = 150;
    }

    // ��ũ �нú� Ȱ��ȭ �������̵�� �����Լ� �̿�
    public override void Hit(float damage)
    {
        damage *= 0.9f;

        base.Hit(damage);
    }
}
