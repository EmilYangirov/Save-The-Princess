using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using YandexMobileAds;

public class AdsButton : MenuButton
{
    private bool collectInformation;
    private string saveKey = "adsKey";

    protected override void Start()
    {
        base.Start();
        LoadAdsStatus();
        ChangeAdsStatus();
    }
    public override void OnButtonClick()
    {
        base.OnButtonClick();

        if (collectInformation)
        {
            collectInformation = false;
            ChangeAdsStatus();
        } else
        {
            collectInformation = true;
            ChangeAdsStatus();
        }
    }

    private void LoadAdsStatus()
    {
        if(PlayerPrefs.HasKey(saveKey) && PlayerPrefs.GetInt(saveKey) == 1)
        {
            collectInformation = true;
            ChangeAdsStatus();
            base.OnButtonClick();
        }
        else
        {
            collectInformation = false;
            ChangeAdsStatus();
        }
    }

    private void ChangeAdsStatus()
    {
        if (collectInformation)
        {
            MetaData gdprMetaData = new MetaData("gdpr");
            gdprMetaData.Set("consent", "true");
            Advertisement.SetMetaData(gdprMetaData);
            MobileAds.SetUserConsent(true);
            PlayerPrefs.SetInt(saveKey, 1);
        } else
        {
            MetaData gdprMetaData = new MetaData("gdpr");
            gdprMetaData.Set("consent", "false");
            Advertisement.SetMetaData(gdprMetaData);
            MobileAds.SetUserConsent(false);
            PlayerPrefs.SetInt(saveKey, 0);
        }
    }
}
