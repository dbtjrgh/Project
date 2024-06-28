using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
	Coin,
	Food,
	Wood,
	Metal,
	Crystal
}

//함수 또는 생성자 호출 시 [파라미터이름] = [값] 형태로 파라미터 순서에 상관없이 전달 가능
[CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Objects/Currency Data", order = 0)]
public class CurrencyData : ScriptableObject
{
	//재화 데이터를 구조화 한 Scriptable Object
	public string currencyName;
	public Sprite iconSprite;
	public CurrencyType currencyType;
	public int maxCount;

}
