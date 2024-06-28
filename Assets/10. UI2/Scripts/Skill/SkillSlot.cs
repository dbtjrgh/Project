using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image iconImage;
    public Image cooldownOverlay;
    internal Skill skill = null;
    protected bool isOnCooldown = false;

    private Vector2 originalPosition;

    private void Awake()
    {
        originalPosition = iconImage.rectTransform.anchoredPosition;
    }

    private void Start()
    {
        Skill = skill;
        cooldownOverlay.fillAmount = 1f;
    }

    public virtual Skill Skill
    {
        get { return skill; }
        set
        {
            skill = value;
            if (iconImage != null)
            {
                if (skill == null)
                {
                    iconImage.enabled = false;
                    if (cooldownOverlay != null)
                    {
                        cooldownOverlay.fillAmount = 0f;
                    }
                }
                else
                {
                    iconImage.enabled = true;
                    iconImage.sprite = skill.iconSprite;
                }
            }
        }
    }

    public virtual bool TrySwap(Skill skill)
    {
        if (!isOnCooldown && this.skill != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool hasSkill { get { return skill != null; } }

    public void OnDrag(PointerEventData data)
    {
        if (!hasSkill || isOnCooldown)
        {
            return;
        }
        iconImage.rectTransform.position = data.position;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (!hasSkill || isOnCooldown)
        {
            return;
        }
        iconImage.rectTransform.SetParent(SkillManager.Instance.SkillPage);
        SkillManager.Instance.selectedSlot = this;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (!hasSkill || isOnCooldown)
        {
            iconImage.rectTransform.anchoredPosition = originalPosition; // Reset to original position if not equipped
            return;
        }

        if (SkillManager.Instance.focusedSlot != this && SkillManager.Instance.focusedSlot != null)
        {
            SkillSlot targetSlot = SkillManager.Instance.focusedSlot;

            if (targetSlot.TrySwap(skill))
            {
                Skill tempItem = targetSlot.Skill;
                targetSlot.Skill = skill;
                this.Skill = tempItem;
            }
        }

        SkillManager.Instance.selectedSlot = null;
        iconImage.rectTransform.SetParent(transform);
        iconImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SkillManager.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SkillManager.Instance.focusedSlot = null;
    }
}