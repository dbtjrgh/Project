using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEasyToggleTest : MonoBehaviour
{

	public Color changeColor;

	public Image targetImage;

	public void OnToggleValueChange(bool isOn)
	{
		// 이 함수는 toggle이 on Value Change 이벤트로 호출 할 함수
		if(isOn)
		{
			targetImage.color = changeColor;

			print($"{name} toggle is on");
		}
		else
		{
			print($"{name} toggle is off");
		}
	}

}
