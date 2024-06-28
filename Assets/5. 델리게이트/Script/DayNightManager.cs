using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
	public static DayNightManager instance { get; private set; }

	public Transform lightTransform; // Directional Light ������Ʈ ����

	private bool isDay = true; // ���̸� true, ���̸� false

    // observer Pattern�� �κ������� ����                                                                                                                                                                                                                                                                   
	public Action<bool> onDayComesUp;
    // ����Ƽ���� ������ ���� ���� �� delegate �Ǵ� eventHandler�� �ַ� Ȱ��

    private void Awake()
    {
        instance = this;
        onDayComesUp = (isDay) => 
		{
            lightTransform.rotation = Quaternion.Euler(isDay ? 30 : 190, 0, 0);
        };
    }
    public void DayToggleButtonClick() 
	{
		// �㳷 ��� ��ư�� ȣ��
		isDay = !isDay; // isDay ���
        onDayComesUp?.Invoke(isDay);
	}
}
