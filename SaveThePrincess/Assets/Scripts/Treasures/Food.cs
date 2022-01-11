using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Treasure
{
    private CharacterLvl caharcterLevel;

    public override void GiveStats()
    {
        caharcterLevel = player.GetComponent<CharacterLvl>();
        caharcterLevel.changeValue(giveme);
    }
}
