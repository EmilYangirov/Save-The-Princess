using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] musicClips;
    
    private SoundPlayer soundPlayer;

    private void Awake()
    {
        soundPlayer = new SoundPlayer(gameObject);
    }

    private void Update()
    {
        if (!soundPlayer.audioSource.isPlaying)
            soundPlayer.PlaySound(musicClips);
    }
}
