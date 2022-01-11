using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUISize : MonoBehaviour
{
    private Transform target, player;
    public RectTransform uiTransform;
    private Vector2 startScale;

    private void Start()
    {
        target = transform;        
        player = GameObject.FindWithTag("Character").transform;
        startScale = uiTransform.localScale;
        uiTransform.localScale = new Vector2(0, 0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform == player)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeSize(startScale));            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == player)
        {
            StopAllCoroutines();
            StartCoroutine(ChangeSize(new Vector2(0, 0)));
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
