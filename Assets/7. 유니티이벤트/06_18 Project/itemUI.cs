using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Text itemName;
    public Image itemIcon;

    public void SetData(string name, Sprite icon)
    {
        itemName.text = name;
        itemIcon.sprite = icon;
    }
}