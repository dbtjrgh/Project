using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾� �����͸� �����ϴ� Ŭ����
public class Itemdata
{
    private int[] ItemArray =
        //Enum.GetValues : ������ Ÿ�� ���� ��� ���θ� �������� �Լ�
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