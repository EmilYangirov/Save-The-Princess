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
        valueToIncreaseLvl = 5 + 5 * level;
        ch.maxHealth = healthByLvl[level];
        ch.baseDamage = damageByLvl[level];
        ch.ModifyCharacterDamage();
    }

    public void ChangeValue(float addValue, bool start = false)
    {
        value += addValue;
        if (!start)
        {
            while (value >= valueToIncreaseLvl)
            {
                value = value - valueToIncreaseLvl;                
                IncreaseLvl();
            }

            SetStats();
        }

    }

}
