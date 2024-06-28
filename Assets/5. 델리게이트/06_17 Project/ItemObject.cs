using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    [Serializable]
    public class Item
    {
        public string name;
        public GameObject uiElement;
        public bool isWeapon;
        public bool isConsumable;
        public bool isEquipment;
        public bool isOther;
    }

    public List<Item> items = new List<Item>();

    private void Start()
    {
        InitializeItems();
    }

    private void InitializeItems()
    {

    }

    public void ToggleWeapons()
    {
        SetItemTransparency(item => item.isWeapon);
    }

    public void ToggleConsumables()
    {
        SetItemTransparency(item => item.isConsumable);
    }

    public void ToggleEquipment()
    {
        SetItemTransparency(item => item.isEquipment);
    }

    public void ToggleOther()
    {
        SetItemTransparency(item => item.isOther);
    }

    private void SetItemTransparency(Func<Item, bool> categoryPredicate)
    {
        foreach (var item in items)
        {
            SetTransparency(item.uiElement, categoryPredicate(item) ? 1f : 0.5f);
        }
    }

    private void SetTransparency(GameObject uiElement, float alpha)
    {
        Image image = uiElement.GetComponent<Image>();
        if (image != null)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }
}
