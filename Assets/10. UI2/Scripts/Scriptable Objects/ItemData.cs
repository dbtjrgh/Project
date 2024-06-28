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

//�Լ� �Ǵ� ������ ȣ�� �� [�Ķ�����̸�] = [��] ���·� �Ķ���� ������ ������� ���� ����
[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/Item Data", order = 0)]
public class ItemData : ScriptableObject
{
	public string itemName;
	public Sprite iconSprite;
	public ItemType currencyType;

}
