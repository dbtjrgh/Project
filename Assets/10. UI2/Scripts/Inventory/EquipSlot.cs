using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : InventorySlot
{

    public Image defaultIconImage; //�������� ���� �������� ������ ������
    public PlayerEquip playerEquip;
    public int handIndex;

    //Set item�� �Ҷ�
    //item propertie �� ���� �����Ҷ��� ������ ����
    public override Item Item
    {
        get => base.Item;
        set
        {
            if (value is Weapon)
            {
                //�������� �������� �����
                playerEquip.EquipWeapon(handIndex, value as Weapon);
                defaultIconImage.enabled = false;
                base.Item = value;
            }
            else if (value == null)
            {
                //���⸦ �����Ϸ� �� �� null�� ����.
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
