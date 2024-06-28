using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	Belt,
	Bomb,
	Bow,
	Arrow,
	Key,
	Potion,
	Hammer,
	Map
}

//함수 또는 생성자 호출 시 [파라미터이름] = [값] 형태로 파라미터 순서에 상관없이 전달 가능
[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/Item Data", order = 0)]
public class ItemData : ScriptableObject
{
	public string itemName;
	public Sprite iconSprite;
	public ItemType currencyType;

}
