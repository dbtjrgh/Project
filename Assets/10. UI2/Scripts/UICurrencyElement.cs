using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UICurrencyElement : MonoBehaviour
{

	public Image iconImage;
	public TextMeshProUGUI nameText;
	public Slider progressBar;
	public TextMeshProUGUI progressText;
	private CurrencyData data;

	public void SetData(CurrencyData data)
	{
		this.data = data;
		//currency element가 생성되고나서 호출 될 초기화 함수.

		iconImage.sprite = data.iconSprite;//아이콘 교체
		nameText.text = data.currencyName;//이름 변경

		//진행바 최소/최대값 할당
		progressBar.minValue = 0;
		progressBar.maxValue = data.maxCount;

		int currentCount = DataManager.Instance.playerData[data.currencyType];

		//진행바 텍스트 변경
		progressText.text = $"{currentCount} / {data.maxCount.ToString()}";

		//진행바 현재값 할당
		progressBar.value = currentCount;

		//재화 값이 변경 될때 호출되도록 delegate stack에 추가
		DataManager.Instance.onCurrencyAmountChange += OnCurrencyAmountChange;
	}

	public void OnCurrencyAmountChange(CurrencyType type, int count)
	{

		if (type == data.currencyType)
		{
			progressBar.value = count;
			progressText.text = $"{count} / {data.maxCount.ToString()}";
		}
	}
}
