using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUISize : MonoBehaviour
{
    public RectTransform uiTransform;
    private Vector2 startScale;
    private bool fullSize;

    [SerializeField]
    private AudioClip showAudio;

    private SoundPlayer soundPlayer;

    protected virtual void Start()
    {
        soundPlayer = new SoundPlayer(gameObject);
        startScale = uiTransform.localScale;
        uiTransform.localScale = new Vector2(0, 0);
    }

    public virtual void CloseAndShowUiElement()
    {
        StopAllCoroutines();

        if (fullSize)
        {
            StartCoroutine(ChangeSize(Vector2.zero));
            fullSize = false;
        }
        else
        {
            StartCoroutine(ChangeSize(startScale));
            fullSize = true;
            soundPlayer.PlaySound(showAudio);
        }
    }
    
    private IEnumerator ChangeSize(Vector2 size)
    {
        float time = 0;
        while (time < 0.5f)
        {
            uiTransform.localScale = Vector2.Lerp(uiTransform.localScale, size, 8 * Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
        uiTransform.localScale = size;
    }   
    
}
