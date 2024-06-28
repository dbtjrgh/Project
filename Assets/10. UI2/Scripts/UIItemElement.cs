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
		//currency element가 생성되고나서 호출 될 초기화 함수.

		iconImage.sprite = data.iconSprite;//아이콘 교체
		nameText.text = data.itemName;//이름 변경
	}
}
