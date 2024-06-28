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
		// �� �Լ��� toggle�� on Value Change �̺�Ʈ�� ȣ�� �� �Լ�
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
