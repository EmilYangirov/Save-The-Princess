using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : MonoBehaviour
{
    [SerializeField]
    private AudioClip levelUpAudio;

    private SoundPlayer soundPlayer;

    private void Start()
    {
        soundPlayer = new SoundPlayer(gameObject);
        soundPlayer.PlaySound(levelUpAudio);

        StartCoroutine(DestroyAfterLife());
    }

    private IEnumerator DestroyAfterLife()
    {    
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
}
