using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDieCounter : MonoBehaviour
{
    public event Action ShowInterstitial;
    public event Action ShowBanner;
    public void OnCharacterDie()
    {
        int characterDieCount = 1;
        ShowBanner?.Invoke();

        if (!PlayerPrefs.HasKey("DieCount"))
        {
            PlayerPrefs.SetInt("DieCount", characterDieCount);
        }
        else
        {
            characterDieCount = PlayerPrefs.GetInt("DieCount") + 1;

            if (characterDieCount >= 2)
            {
                characterDieCount = 0;
                ShowInterstitial?.Invoke();
            }
            Debug.Log(characterDieCount);
            PlayerPrefs.SetInt("DieCount", characterDieCount);
        }
    }
}
