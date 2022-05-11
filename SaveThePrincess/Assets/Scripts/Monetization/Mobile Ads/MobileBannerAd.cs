using System;
using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine.Advertisements;
using UnityEngine;

public class MobileBannerAd 
{
    private Banner banner;

    private string androidAdUnitId = "Banner_Android";
    private string iOsAdUnitId = "Banner_iOS";
    private string adUnitId;

    public MobileBannerAd()
    {
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
               ? iOsAdUnitId
               : androidAdUnitId;
        
        LoadUnityBanner();
    }

    public void RequestBanner()
    {
        string adUnitId = "R-M-1625179-1";

        DestroyBanner();

        this.banner = new Banner(adUnitId, AdSize.BANNER_320x50, AdPosition.BottomCenter);

        this.banner.OnAdLoaded += this.HandleAdLoaded;
        this.banner.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.banner.OnReturnedToApplication += this.HandleReturnedToApplication;
        this.banner.OnLeftApplication += this.HandleLeftApplication;
        this.banner.OnImpression += this.HandleImpression;

        this.banner.LoadAd(this.CreateAdRequest());
    }

    private void LoadUnityBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }

    public void ShowUnityBanner()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        Advertisement.Banner.Show(adUnitId, options);
    }  

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void DestroyBanner()
    {
        if (this.banner != null)
        {
            this.banner.Destroy();
        }

        HideBannerAd();
    }

    void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        this.banner.Show();
    }

    public void HandleAdFailedToLoad(object sender, AdFailureEventArgs args)
    {
        ShowUnityBanner();
    }

    public void HandleLeftApplication(object sender, EventArgs args)
    {
    }

    public void HandleReturnedToApplication(object sender, EventArgs args)
    {
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
    }

    public void HandleImpression(object sender, ImpressionData impressionData)
    {
        var data = impressionData == null ? "null" : impressionData.rawData;
    }

    #endregion

    #region Unity Banner Callback

    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
    }

    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }   
   

    void OnBannerClicked() { }
    void OnBannerShown() 
    {
        LoadUnityBanner();
    }
    void OnBannerHidden() { }

    #endregion
}
