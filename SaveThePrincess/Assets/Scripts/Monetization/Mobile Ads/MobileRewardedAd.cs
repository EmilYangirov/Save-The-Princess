using System;
using YandexMobileAds;
using YandexMobileAds.Base;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;

public class MobileRewardedAd : IUnityAdsLoadListener, IUnityAdsShowListener
{
    public RewardedAd rewardedAd;
    private Restart rewardScript;
    private int restarRequestCounter;

    private string androidAdUnitId = "Rewarded_Android";
    private string iOsAdUnitId = "Rewarded_iOS";
    private string adUnitId;

    public MobileRewardedAd(Restart _rewardScript)
    {
        rewardScript = _rewardScript;

        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
           ? iOsAdUnitId
           : androidAdUnitId;

        LoadUnityAd();
    }

    private void LoadUnityAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowUnityAd()
    {
        Advertisement.Show(adUnitId, this);
    }

    public void RequestRewardedAd()
    {      
        string adUnitId = "R-M-1625179-3";
        DestroyRewardedAd();
        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnRewardedAdLoaded += this.HandleRewardedAdLoaded;
        this.rewardedAd.OnRewardedAdFailedToLoad += this.HandleRewardedAdFailedToLoad;
        this.rewardedAd.OnReturnedToApplication += this.HandleReturnedToApplication;
        this.rewardedAd.OnLeftApplication += this.HandleLeftApplication;
        this.rewardedAd.OnRewardedAdShown += this.HandleRewardedAdShown;
        this.rewardedAd.OnRewardedAdDismissed += this.HandleRewardedAdDismissed;
        this.rewardedAd.OnImpression += this.HandleImpression;
        this.rewardedAd.OnRewarded += this.HandleRewarded;

        this.rewardedAd.LoadAd(this.CreateAdRequest());       
    }

    private void ShowRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    public void DestroyRewardedAd()
    {
        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();
        }
    }

    private void GetReward()
    {
        rewardScript.ChangeResurrectStatus();
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    #region Rewarded Ad callback handlers

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        ShowRewardedAd();
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailureEventArgs args)
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

    public void HandleRewardedAdShown(object sender, EventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleRewardedAdFailedToShow(object sender, AdFailureEventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleRewardedAdDismissed(object sender, EventArgs args)
    {
        throw new NotImplementedException();
    }

    public void HandleImpression(object sender, ImpressionData impressionData)
    {
        throw new NotImplementedException();
    }

    public void HandleRewarded(object sender, Reward args)
    {
        GetReward();
    }
    #endregion

    #region Unity Rewarded Ad Callback

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");

    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            GetReward();
        }

        LoadUnityAd();        
    }
    #endregion
}

