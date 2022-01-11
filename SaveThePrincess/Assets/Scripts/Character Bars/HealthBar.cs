using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : CharacterBar
{
    private Character character;

    private void Start()
    {
        character = gameObject.GetComponent<Character>();
        character.chBars.Add(this);
        maxValue = character.maxHealth;
        value = character.health;
        CreateBar();
        CheckBar();
    }

    public override void CheckBar()
    {
        maxValue = character.maxHealth;
        value = character.health;
        base.CheckBar();
    }
}