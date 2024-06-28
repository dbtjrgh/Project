using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public Text promptText;

    private void Start()
    {
        HidePrompt();
    }

    public void ShowPrompt()
    {
        promptText.enabled = true;
    }

    public void HidePrompt()
    {
        promptText.enabled = false;
    }
}
