using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EquipSkillSlot : SkillSlot
{
    public Image defaultIconImage;
    public int handIndex;

    public override Skill Skill
    {
        get => base.Skill;
        set
        {
            if (value != null)
            {
                defaultIconImage.enabled = false;
                base.Skill = value;
                StartCooldown();
            }
            else
            {
                defaultIconImage.enabled = true;
                base.Skill = null;
                cooldownOverlay.fillAmount = 1f; // Reset cooldown overlay to full when skill is unequipped
            }
        }
    }

    private void StartCooldown()
    {
        StartCoroutine(CooldownCoroutine(5f)); // 5ÃÊ Äð´Ù¿î
    }

    private IEnumerator CooldownCoroutine(float cooldownDuration)
    {
        cooldownOverlay.fillAmount = 1f; // Initial cooldown fill amount set to full
        isOnCooldown = true;
        float elapsed = 0f;

        while (elapsed < cooldownDuration)
        {
            elapsed += Time.deltaTime;
            cooldownOverlay.fillAmount = 1f - (elapsed / cooldownDuration);
            yield return null;
        }

        cooldownOverlay.fillAmount = 0f;
        isOnCooldown = false;
    }
}