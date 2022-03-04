using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLvl : LevelSystem
{
    public float[] damageByLvl;
    public float[] healthByLvl;
    public float value, valueToIncreaseLvl;
    private Character ch;
    public Text lvlText;
    public string lvlString;

    protected void Start()
    {
        ch = gameObject.GetComponent<Character>();
        lvlText.text = lvlString + level;
        SetStats();
    }

    public override void IncreaseLvl()
    {
        if(level < maxLevel)
        {
            level++;
            if (lvlText != null)
            {
                lvlText.text = lvlString + level;
            }
            SetStats();
        }       
    }
    
    public override void SetStats()
    {
        ch.baseHealth = healthByLvl[level];
        ch.baseDamage = damageByLvl[level];
        ch.ModifyCharacterStats();
        ch.CheckBars();
    }

    public void ChangeValue(float addValue)
    {
        value += addValue;
        ch.CheckBars();
        while (value >= valueToIncreaseLvl)
        {
            value = value - valueToIncreaseLvl;
            valueToIncreaseLvl *= 2;
            IncreaseLvl();
        }
    }
}
