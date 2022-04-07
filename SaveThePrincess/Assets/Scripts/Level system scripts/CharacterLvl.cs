using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterLvl : LevelSystem
{
    public float[] damageByLvl;
    public float[] healthByLvl;
    public float value, valueToIncreaseLvl;
    private Character ch;
    public TextMeshProUGUI levelText;

    [SerializeField]
    private GameObject levelPrefab;

    protected void Start()
    {        
        ch = gameObject.GetComponent<Character>();
        levelText.text = ": " + level;
        SetStats();
    }

    public override void IncreaseLvl()
    {
        if(level < maxLevel)
        {
            GameObject levelUpGo = Instantiate(levelPrefab, Vector2.zero, Quaternion.identity, gameObject.transform);
            levelUpGo.transform.localPosition = Vector2.zero; 
            level++;

            if (levelText != null)
            {
                levelText.text = ": " + level;
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

    public void DecreaseLevel (int decreaseValue)
    {        
        level -= decreaseValue;

        if(decreaseValue > 0)
            value = 0;

        if (level < 0)
            level = 0;
    }

}
