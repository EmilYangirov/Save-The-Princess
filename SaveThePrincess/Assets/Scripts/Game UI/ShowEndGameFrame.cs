using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEndGameFrame : ChangeUISize
{
    private AudioSource musicSource;
    private bool gameEnded = false;

    protected override void Start()
    {
        base.Start();

        GameObject camera = Camera.main.gameObject;
        musicSource = camera.GetComponent<AudioSource>();
    }

    public override void CloseAndShowUiElement()
    {
        if (!gameEnded)
        {
            base.CloseAndShowUiElement();
            musicSource.mute = true;
            gameEnded = true;
        }
    }
}
