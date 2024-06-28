using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIDropdownTest : MonoBehaviour
{
	private Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }

    public void OnDropdownValueChange(int value)
    {
        print($"{dropdown.options[value].text} selected.");
    }
    private char charTemp = 'E';
    public void OnAddoptionButtonClick()
    {
        charTemp += (char)((int)charTemp + 1);
        string optionName = $"Option {charTemp}";

        Dropdown.OptionData optionData = new Dropdown.OptionData();
        optionData.text = optionName;

        dropdown.options.Add(optionData);
    }
}
