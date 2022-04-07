using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguageButton : MenuButton
{
    [SerializeField]
    private Localization localization;

    protected override void Start()
    {
        buttonImage = GetComponent<Image>();
        imageChangeble = true;

        ChangeButtonImage();
    }
    protected override void ChangeButtonImage()
    {
        if(Localization.selectedLanguage == 1)
        {
            buttonImage.sprite = activeImage;
        } else
        {
            buttonImage.sprite = inactiveImage;
        }
    }
    public override void OnButtonClick()
    {
        if(Localization.selectedLanguage == 0)
        {
            localization.SetLanguage(1);
        } else
        {
            localization.SetLanguage(0);
        }

        base.OnButtonClick();
    }
}
