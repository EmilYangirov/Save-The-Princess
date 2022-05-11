using UnityEngine;
using UnityEngine.Advertisements;
using YandexMobileAds;
using YandexMobileAds.Base;


public class MobileAdCreator : MonoBehaviour, IUnityAdsInitializationListener
{
    private MobileInterstitialAd interstitial;
    private MobileBannerAd banner;
    private MobileRewardedAd rewarded;
    private Restart rewardClass;
    private CharacterDieCounter characterDie;

    [SerializeField]
    private string androidGameId = "4703610";
    [SerializeField]
    private string iosGameId = "4703611";

    private string gameId;
    private bool testMode = false;

    private void Start()
    {
        InitUnityAds();

        interstitial = new MobileInterstitialAd();        
        banner = new MobileBannerAd();

        GameObject levelManager = GameObject.FindGameObjectWithTag("levelmanager");
        rewardClass = levelManager.GetComponent<Restart>();
        rewarded = new MobileRewardedAd(rewardClass);

        characterDie = GetComponent<CharacterDieCounter>();
        characterDie.ShowInterstitial += ShowInterstitialAd;
        characterDie.ShowBanner += ShowBannerAd;
        rewardClass.onRestart += DestroyAds;

       
    }

    private void InitUnityAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iosGameId
            : androidGameId;

        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowRewarded()
    {
        rewarded.RequestRewardedAd();
    }
    public void ShowInterstitialAd()
    {
        interstitial.RequestInterstitial();
    }

    public void ShowBannerAd()
    {
        banner.RequestBanner();
    }

    private void DestroyAds()
    {
        banner.DestroyBanner();
        interstitial.DestroyInterstetialAd();
        rewarded.DestroyRewardedAd();
    }

    private void OnDisable()
    {
        characterDie.ShowInterstitial -= ShowInterstitialAd;
        characterDie.ShowBanner -= ShowBannerAd;
        rewardClass.onRestart -= DestroyAds;
    }

    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
