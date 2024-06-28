using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//����Ƽ �̺�Ʈ �ڵ鷯 �������̽�
//ȣ�� ��ü : EventSystem
public class InventorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler
    , IPointerEnterHandler, IPointerExitHandler
{

    public Image iconImage;
    //internal : ������ Assembly (���� project ��) ���� �ִ� �ٸ� Ÿ�Ե��� ������ �� �� �ִ�.
    //������, �ٸ� ����������� ������ �Ұ��ϴ�.
    //����Ƽ������ Inspector���� ������ �ȵǰ�, ��� �ٸ� ��ũ��Ʈ������ ������ ����.
    //������Ÿ���� �� ���� ������ �ʿ��Ҷ� HideInInspector ��Ʈ����Ʈ�� ��ü�Ͽ� Ȱ��.
    internal Item item = null;

    private void Start()
    {
        Item = item;
    }

    public virtual Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = item.iconSprite;
            }
        }
    }

    public virtual bool TrySwap(Item item)
    {
        if (item is Weapon && hasItem)
        {
            if (this.item is Weapon)
            {
                return true;
            }
            else return false;
        }
        return true;
    }

    //item �ʵ尡 null�ϰ�� false, null�� �ƴҰ�� true ��ȯ
    public bool hasItem { get { return item != null; } }

    public void OnDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }
        //RectTransform.position : ��ũ�� �󿡼��� ��ġ
        iconImage.rectTransform.position = data.position;

    }

    public void OnBeginDrag(PointerEventData data)
    {

        //not ������ !
        if (false == hasItem)
        { //�������� ���ؼ� ! ������ ��� false == ������ ����
            return;
        }

        //Transform.SetParent : ���̾��Ű�� �θ� ��������.
        //�Ķ���ͷ� null�� �Ҵ��� ��� �θ� ���� �� ������� �̵���.
        iconImage.rectTransform.SetParent(InventoryManager.Instance.equipPage);

        //�巡�װ� �����Ҷ� �κ� �Ŵ������� 1�� ����(�� �ڽ�)�� ���ý������� ����
        InventoryManager.Instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }
        //�巡�װ� �������� ������ ���� ������ : focused slot == this
        //�巡�װ� �������� �κ��丮 ������ �ƴҶ� : focused slot == null


        // !(a == b || a == c)
        // a != b && a != c 

        //��ȿ�� �巡��
        if (InventoryManager.Instance.focusedSlot != this && InventoryManager.Instance.focusedSlot != null)
        {

            InventorySlot targetSlot = InventoryManager.Instance.focusedSlot;

            if (targetSlot.TrySwap(item))
            {
                Item tempItem = targetSlot.Item;
                targetSlot.Item = item;
                this.Item = tempItem;
            }
        }

        InventoryManager.Instance.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);
        //anchoredPosition : ��Ŀ�κ����� ����� ��ġ
        iconImage.rectTransform.anchoredPosition = Vector2.zero;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManager.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.focusedSlot = null;
    }
}
