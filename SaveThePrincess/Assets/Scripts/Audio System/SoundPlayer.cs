using System;
using UnityEngine;

public class SoundPlayer
{
    public AudioSource audioSource { get; private set; }

    public SoundPlayer(GameObject creator)
    {
        audioSource = creator.AddComponent<AudioSource>();
    }    

    public void PlaySound(AudioClip[] audioClips)
    {
        if (!audioSource.isPlaying && audioClips.Length != 0)
        {
            int audioIndex = UnityEngine.Random.Range(0, audioClips.Length);
            audioSource.PlayOneShot(audioClips[audioIndex]);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (!audioSource.isPlaying && audioClip != null)
        {            
            audioSource.PlayOneShot(audioClip);
        }
    }
}
