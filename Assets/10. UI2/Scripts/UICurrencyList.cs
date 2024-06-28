using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrencyList : MonoBehaviour
{
	//currency element가 생성되어 content의 자식 객체로 만들어야 함.
	public Transform content;//Scroll view List 내부 Transform
	public UICurrencyElement CurrencyElementPrefab; //element UI 요소를 프리팹으로 참조하여 생성

	public void Initialize()
	{
		foreach (CurrencyData data in DataManager.Instance.currencyDataList)
		{
			Instantiate(CurrencyElementPrefab, content).SetData(data); //Currency Element 생성
		}
	}
}
