using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//유니티 이벤트 핸들러 인터페이스
//호출 주체 : EventSystem
public class InventorySlot : MonoBehaviour,
    IDragHandler, IBeginDragHandler, IEndDragHandler
    , IPointerEnterHandler, IPointerExitHandler
{

    public Image iconImage;
    //internal : 동일한 Assembly (같은 project 내) 내에 있는 다른 타입들이 엑세스 할 수 있다.
    //하지만, 다른 어셈블리에서는 접근이 불가하다.
    //유니티에서는 Inspector에서 참조가 안되고, 대신 다른 스크립트에서는 접근이 가능.
    //프로토타입핑 등 빠른 구현이 필요할때 HideInInspector 어트리뷰트를 대체하여 활용.
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

    //item 필드가 null일경우 false, null이 아닐경우 true 반환
    public bool hasItem { get { return item != null; } }

    public void OnDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }
        //RectTransform.position : 스크린 상에서의 위치
        iconImage.rectTransform.position = data.position;

    }

    public void OnBeginDrag(PointerEventData data)
    {

        //not 연산자 !
        if (false == hasItem)
        { //가독성을 위해서 ! 연산자 대신 false == 쓸때도 있음
            return;
        }

        //Transform.SetParent : 하이어라키상 부모를 지정해줌.
        //파라미터로 null을 할당할 경우 부모 없이 최 상단으로 이동함.
        iconImage.rectTransform.SetParent(InventoryManager.Instance.equipPage);

        //드래그가 시작할때 인벤 매니저에게 1개 슬롯(나 자신)을 선택슬롯으로 저장
        InventoryManager.Instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            return;
        }
        //드래그가 끝난곳이 시작한 곳과 같을때 : focused slot == this
        //드래그가 끝난곳이 인벤토리 슬롯이 아닐때 : focused slot == null


        // !(a == b || a == c)
        // a != b && a != c 

        //유효한 드래그
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
        //anchoredPosition : 앵커로부터의 상대적 위치
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
