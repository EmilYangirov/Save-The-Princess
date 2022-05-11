using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyMenu : MonoBehaviour
{
    private string privacyKey = "privacy";

    private CanvasGroup privacyCanvas;

    [SerializeField]
    private CanvasGroup dialogueCanvas;

    [SerializeField]
    private GameObject privacyWindow, adsWindow;

    private void Start()
    {
        privacyCanvas = GetComponent<CanvasGroup>();

        if (!PlayerPrefs.HasKey(privacyKey))
            ShowPrivacyWindow();
        else
            HidePrivacyWindow();
    }

    public void ShowPrivacyWindow()
    {        
        Time.timeScale = 0;
        privacyCanvas.alpha = 1;
        privacyCanvas.interactable = true;
        privacyCanvas.blocksRaycasts = true;

        ActivatePrivacyWindow();
    }

    public void SavePrefs()
    {
        if (!PlayerPrefs.HasKey(privacyKey))
            PlayerPrefs.SetInt(privacyKey, 1);
    }

    public void HidePrivacyWindow()
    {       
        privacyCanvas.alpha = 0;
        privacyCanvas.interactable = false;
        privacyCanvas.blocksRaycasts = false;

        if(dialogueCanvas.alpha == 0)
            Time.timeScale = 1;
    }

    private void ActivatePrivacyWindow()
    {
        if (PlayerPrefs.HasKey(privacyKey))
        {
            privacyWindow.SetActive(false);
            adsWindow.SetActive(true);
        } else
        {
            privacyWindow.SetActive(true);
            adsWindow.SetActive(false);
        }
    }
    
}
