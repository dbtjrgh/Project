using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public RectTransform equipPage;
    public RectTransform inventoryContent;

    public int inventorySlotCount;// 생성할 슬롯 개수
    public InventorySlot inventorySlotPrefab;//슬롯 프리팹
    private List<InventorySlot> inventorySlots = new();//슬롯 리스트

    [Space(20)]
    public InventorySlot focusedSlot;
    public InventorySlot selectedSlot;

    public List<Weapon> tempWeapons;
    public List<Item> tempItems;

    private void Start()
    {

        //tempItems 리스트에 tempWeapons요소들을 0번 인덱스부터 삽입
        tempItems.InsertRange(0, tempWeapons);

        for (int i = 0; i < tempItems.Count; i++)
        {
            //임시 아이템을 inventory content 내의 슬롯에 한개씩 할당.
            inventoryContent.GetChild(i).GetComponent<InventorySlot>().Item = tempItems[i];
        }
    }

}

[Serializable]
public class Item
{
    public Sprite iconSprite;//아이템 아이콘
    public string name;//아이템 이름
    public string desc;//아이템 설명
}
[Serializable]
public class Weapon : Item
{
    public float damage;//데미지
    public GameObject equipPrefab;//착용시 생성할 아이템 장비 프리팹
}