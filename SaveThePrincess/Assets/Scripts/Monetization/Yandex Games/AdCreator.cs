using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdCreator : MonoBehaviour
{
    private YandexSDK sdk;
    private Restart rewardScript;

    private void Start()
    {
        sdk = YandexSDK.Instance;
        sdk.RewardGet += GetReward;

        var levelManager = GameObject.FindGameObjectWithTag("levelmanager");
        rewardScript = levelManager.GetComponent<Restart>();
    }

    public void ShowInterstitialAd()
    {
        sdk.ShowCommonAdvertisment();
    }

    public void OnCharacterDie()
    {
        int characterDieCount = 1;

        if (!PlayerPrefs.HasKey("DieCount"))
        {
            PlayerPrefs.SetInt("DieCount", characterDieCount);
        } else
        {
            characterDieCount = PlayerPrefs.GetInt("DieCount") + 1;

            if(characterDieCount >= 3)
            {
                characterDieCount = 0;
                ShowInterstitialAd();
            }

            PlayerPrefs.SetInt("DieCount", characterDieCount);
        }
    }

    public void ShowRewardedAd()
    {
        sdk.ShowRewardAdvertisment();
    }

    private void GetReward()
    {
      rewardScript.ChangeResurrectStatus();       
    }

    private void OnDisable()
    {
        sdk.RewardGet -= GetReward;
    }
}
