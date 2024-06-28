using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemList : MonoBehaviour
{
    //currency element가 생성되어 content의 자식 객체로 만들어야 함.
    public Transform inventory;//Scroll view List 내부 Transform
    public UIItemElement ItemElementPrefab; //element UI 요소를 프리팹으로 참조하여 생성

    public void Initialize()
    {
        foreach (ItemData data in ItemManager2.Instance.itemDataList)
        {
            Instantiate(ItemElementPrefab, inventory).SetData(data); //Currency Element 생성
        }
    }
}
