using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : CharacterBar
{
    private CharacterLvl characterLevel;

    private new void Awake()
    {
        Character ch = gameObject.GetComponent<Character>();
        ch.chBars.Add(this);
        characterLevel = gameObject.GetComponent<CharacterLvl>();
        maxValue = characterLevel.valueToIncreaseLvl;
        value = characterLevel.value;
        CreateBar();
        CheckBar();
    }

    public override void CheckBar()
    {
        maxValue = characterLevel.valueToIncreaseLvl;
        value = characterLevel.value;
        base.CheckBar();
    }

}

