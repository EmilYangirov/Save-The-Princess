using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLvl : LevelSystem
{
    public float[] damageByLvl;
    public float[] healthByLvl;
    public float value, valueToIncreaseLvl;
    public int lvl;
    private Character ch;
    public Text lvlText;
    public string lvlString;

    protected void Start()
    {
        ch = gameObject.GetComponent<Character>();
        lvlText.text = lvlString + lvl;
        SetStats();
    }

    public override void IncreaseLvl()
    {
        lvl++;
        if (lvlText != null)
        {
            lvlText.text = lvlString + lvl;
        }
        SetStats();
    }
  
    
    public override void SetStats()
    {
        ch.health = healthByLvl[lvl];
        ch.damage = damageByLvl[lvl];
        ch.CheckBars();
    }

    public void changeValue(float addValue)
    {
        value += addValue;
        ch.CheckBars();
        if (value >= valueToIncreaseLvl)
        {
            value = value - valueToIncreaseLvl;
            valueToIncreaseLvl *= 2;
            IncreaseLvl();
        }
    }
}
