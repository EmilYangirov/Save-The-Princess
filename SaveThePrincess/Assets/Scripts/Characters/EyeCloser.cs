using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCloser : MonoBehaviour
{
    [SerializeField]
    private int timeToCloseEyes = 5;

    private int timer;

    private Animator anim;
    private bool changeTime = true;

    private void Start()
    {
        anim = transform.GetComponent<Animator>();
        timer = timeToCloseEyes;
    }
    private void FixedUpdate()
    {
        if (changeTime)
            StartCoroutine(EyesCoroutine());
        
        if (timer == 0)
        {
            anim.SetTrigger("closeeyes");
            timer = timeToCloseEyes;
        }
    }
    private IEnumerator EyesCoroutine()
    {
        changeTime = false;
        yield return new WaitForSeconds(1);
        timer--;
        changeTime = true;
    }
}
