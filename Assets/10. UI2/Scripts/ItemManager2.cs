using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 데이터를 참조하는 클레스
public class Itemdata
{
    private int[] ItemArray =
        //Enum.GetValues : 열거형 타입 내의 요소 전부를 가져오는 함수
        new int[Enum.GetValues(typeof(ItemType)).Length];

    public int this[ItemType type]
    {
        get { return ItemArray[(int)type]; }
        set { ItemArray[(int)type] = value; }
    }
}

public class ItemManager2 : MonoBehaviour
{ 
    public List<ItemData> itemDataList;
    public UIItemList itemList;
    public static ItemManager2 Instance { get; private set; }


    public Action<ItemType, int> onItemAmountChange; //delegate

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itemList.Initialize();
    }
}