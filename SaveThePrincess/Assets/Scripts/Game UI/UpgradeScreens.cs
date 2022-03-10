using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreens : ChangeUISize
{
    private Transform player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Character").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player)
        {
            CloseAndShowUiElement();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == player)
        {
            CloseAndShowUiElement();
        }
    }
}
