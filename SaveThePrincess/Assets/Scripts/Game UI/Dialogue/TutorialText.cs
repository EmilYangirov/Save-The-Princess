using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    private TextMeshProUGUI text;   

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (Application.isMobilePlatform)
            text.text = "MobileTutorial";
        else
            text.text = "ComputerTutorial";

    }
}
