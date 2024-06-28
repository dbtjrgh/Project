using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
	private float maxHP = 100;
	private float currentHP = 100;
	private float hpCache = 100;

	// ����Ƽ �̺�Ʈ (UnityEvent)
	// ����Ƽ Inspector���� ��������Ʈ�� ���� Ư�� �Լ��� ����Ͽ� ȣ�� �� �� �ֵ��� ������� Ŭ����.
	public UnityEvent someEvent;
	public UnityEvent<float> onHPChange;
	public UnityEvent<string> onHPChangeString;

	
	public void SomeMethod()
	{
		print("Some Event Called.");
	}

    private void Start()
    {
		onHPChange.AddListener(PrintCurrentHP);
    }
	public void PrintCurrentHP(float value)
	{
		print($"current Hp Amount is : {value}");
	}

	public void OnValueChanged(float value)
	{
		print(value);
	}

	public void OnPositionChange(Vector2 value)
	{
		transform.position = value;
	}

	public void OnDamageButtonClick()
	{
		currentHP -= 10;
	}

    private void Update()
    {
        if(hpCache != currentHP)
		{
			// hp ���� �ٲ����.
			onHPChange?.Invoke(currentHP/maxHP);
			onHPChangeString?.Invoke((currentHP/maxHP).ToString($"p1"));
			hpCache = currentHP;
		}
    }
}
