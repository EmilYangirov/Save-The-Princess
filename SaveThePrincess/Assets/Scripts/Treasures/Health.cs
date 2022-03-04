using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Treasure
{
    private Character character;

    public override void GiveStats()
    {
        character = player.GetComponent<Character>();
        character.IncreaseHealth(giveme);
    }
}
