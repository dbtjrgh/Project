using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPSliderTest : MonoBehaviour
{
    public float hp;

	private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void OnDamageButtonClick(float damage)
    {
        hp -= damage;
        slider.value = hp;
    }
}
