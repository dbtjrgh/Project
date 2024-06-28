using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
	public Transform PanelParent;
	public GameObject PanelPrefab;
	 
	public void AddPanelButtonClick()
	{
		var child = new GameObject("Image");
		child.transform.SetParent(PanelParent);
		var childImage = child.AddComponent<Image>();

		childImage.color = Color.white; // Color.black

		DayNightManager.instance.onDayComesUp += (isDay) => 
		{
			childImage.color = isDay ? Color.black : Color.white; 
		};
	}
}
