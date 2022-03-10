using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOffAudioButton : MenuButton
{
    private AudioSource musicSource;

    [SerializeField]
    private bool turnOffAllAudio;
    
    protected override void Start()
    {
        base.Start();

        if (!turnOffAllAudio)
        {
            GameObject camera = Camera.main.gameObject;
            musicSource = camera.GetComponent<AudioSource>();
        }
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();

        if (turnOffAllAudio)
        {
            if (AudioListener.pause)
                AudioListener.pause = false;
            else
                AudioListener.pause = true;
        } else
        {
            if(musicSource.mute)
                musicSource.mute = false;
            else
                musicSource.mute = true;
        }
            
    }
}
