using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : InventorySlot
{

    public Image defaultIconImage; //아이템을 장착 안했을때 보여줄 아이콘
    public PlayerEquip playerEquip;
    public int handIndex;

    //Set item을 할때
    //item propertie 에 값을 대입할때의 로직을 수정
    public override Item Item
    {
        get => base.Item;
        set
        {
            if (value is Weapon)
            {
                //넣으려는 아이템이 무기면
                playerEquip.EquipWeapon(handIndex, value as Weapon);
                defaultIconImage.enabled = false;
                base.Item = value;
            }
            else if (value == null)
            {
                //무기를 해제하려 할 때 null을 대입.
                playerEquip.EquipWeapon(handIndex, null);
                defaultIconImage.enabled = true;
                base.Item = value;
            }
        }
    }

    public override bool TrySwap(Item item)
    {

        if (item is Weapon || item is null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
