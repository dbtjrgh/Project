using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public RectTransform SkillPage;
    public RectTransform SkillContent;

    public int skillSlotCount;
    public SkillSlot skillSlotPrefab;
    private List<SkillSlot> skillSlots = new(); // ������ �κ�

    [Space(20)]
    public SkillSlot focusedSlot;
    public SkillSlot selectedSlot;

    public List<Skill> tempSkill;

    private void Start()
    {
        for (int i = 0; i < tempSkill.Count; i++)
        {
            SkillContent.GetChild(i).GetComponent<SkillSlot>().Skill = tempSkill[i];
        }
    }
}

[Serializable]
public class Skill
{
    public Sprite iconSprite; // ��ų ������
    public string name; // ��ų �̸�
    public string desc; // ��ų ����
}