using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffAudioButton : MenuButton
{
    private string key = "audio";

    
    protected override void Start()
    {
        base.Start();
        SetStartAudioStatus();
    }

    public override void OnButtonClick()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt(key, 1);
        } else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt(key, 0);
        }
        ChangeButtonImage();
    }

    private void SetStartAudioStatus()
    {
        if (PlayerPrefs.HasKey(key))
        {
            if(PlayerPrefs.GetInt(key) == 0)
            {
                AudioListener.volume = 0;
                ChangeButtonImage();
            }
        }
    }
}
