using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIItemElement : MonoBehaviour
{

	public Image iconImage;
	public TextMeshProUGUI nameText;
	private ItemData data;

	public void SetData(ItemData data)
	{
		this.data = data;
		//currency element�� �����ǰ��� ȣ�� �� �ʱ�ȭ �Լ�.

		iconImage.sprite = data.iconSprite;//������ ��ü
		nameText.text = data.itemName;//�̸� ����
	}
}
