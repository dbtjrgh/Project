using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemList : MonoBehaviour
{
    //currency element�� �����Ǿ� content�� �ڽ� ��ü�� ������ ��.
    public Transform inventory;//Scroll view List ���� Transform
    public UIItemElement ItemElementPrefab; //element UI ��Ҹ� ���������� �����Ͽ� ����

    public void Initialize()
    {
        foreach (ItemData data in ItemManager2.Instance.itemDataList)
        {
            Instantiate(ItemElementPrefab, inventory).SetData(data); //Currency Element ����
        }
    }
}
