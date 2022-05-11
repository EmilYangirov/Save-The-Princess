using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdCreator : MonoBehaviour
{
    private YandexSDK sdk;
    private Restart rewardScript;
    private CharacterDieCounter characterDie;


    private void Start()
    {
        sdk = YandexSDK.Instance;
        sdk.RewardGet += GetReward;

        characterDie = GetComponent<CharacterDieCounter>();
        characterDie.ShowInterstitial += ShowInterstitialAd;

        var levelManager = GameObject.FindGameObjectWithTag("levelmanager");
        rewardScript = levelManager.GetComponent<Restart>();
    }

    public void ShowInterstitialAd()
    {
        sdk.ShowCommonAdvertisment();
    }
    

    public void ShowRewardedAd()
    {
        sdk.ShowRewardAdvertisment();
    }

    private void GetReward()
    {
        rewardScript.ChangeResurrectStatus();
        rewardScript.PriceResurrect();
    }

    private void OnDisable()
    {
        sdk.RewardGet -= GetReward;
        characterDie.ShowInterstitial -= ShowInterstitialAd;
    }

    public void TurnOffAudio()
    {       
        AudioListener.volume = 0;
    }

    public void TurnOnAudio()
    {
        if (PlayerPrefs.GetInt("audio") == 1 || !PlayerPrefs.HasKey("audio"))
        {
            AudioListener.volume = 1;
        }
    }
}
