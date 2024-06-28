using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
	//currency element�� �����Ǿ� content�� �ڽ� ��ü�� ������ ��.
	public Transform content;//Scroll view List ���� Transform
	public UICurrencyElement CurrencyElementPrefab; //element UI ��Ҹ� ���������� �����Ͽ� ����

	public void Initialize()
	{
		foreach (CurrencyData data in DataManager.Instance.currencyDataList)
		{
			Instantiate(CurrencyElementPrefab, content).SetData(data); //Currency Element ����
		}
	}
}
