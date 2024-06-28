using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISliderTest : MonoBehaviour
{
	// slider의 OnValueChange 이벤트에서 호출.
	public void OnSliderValueChange(float value)
	{
		transform.localScale = Vector3.one * value;
	}
}
