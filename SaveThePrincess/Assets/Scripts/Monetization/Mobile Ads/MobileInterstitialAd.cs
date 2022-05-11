using System;
using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine.Advertisements;
using UnityEngine;

public class MobileInterstitialAd : IUnityAdsLoadListener, IUnityAdsShowListener
{

    private Interstitial interstitial;

    private string androidAdUnitId = "Interstitial_Android";
    private string iOsAdUnitId = "Interstitial_iOS";
    private string adUnitId;

    public MobileInterstitialAd()
    {
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOsAdUnitId
            : androidAdUnitId;

        LoadUnityAd();
    }

    private void LoadUnityAd()
    {
        Advertisement.Load(adUnitId, this);
    }
    private void ShowUnityAd()
    {
        Advertisement.Show(adUnitId, this);
    }
    public void RequestInterstitial()
    {
        string adUnitId = "R-M-1625179-2";

        DestroyInterstetialAd();

        this.interstitial = new Interstitial(adUnitId);

        this.interstitial.OnInterstitialLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnInterstitialFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnReturnedToApplication += this.HandleReturnedToApplication;
        this.interstitial.OnLeftApplication += this.HandleLeftApplication;
        this.interstitial.OnInterstitialShown += this.HandleInterstitialShown;
        this.interstitial.OnInterstitialDismissed += this.HandleInterstitialDismissed;
        this.interstitial.OnImpression += this.HandleImpression;

        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void DestroyInterstetialAd()
    {
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }
    }
    private void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        ShowInterstitial();
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailureEventArgs args)
    {
        ShowUnityAd();
    }

    public void HandleReturnedToApplication(object sender, EventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleLeftApplication(object sender, EventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleInterstitialShown(object sender, EventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleInterstitialFailedToShow(object sender, AdFailureEventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleInterstitialDismissed(object sender, EventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleImpression(object sender, ImpressionData impressionData)
    {
        throw new NotImplementedException();
    }



    #endregion

    #region UnityAds Callbacks
    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadUnityAd();
    }

    #endregion
}