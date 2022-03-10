using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : LevelSystem
{   
    private Character character;
        
    private void Start()
    {        
        Transform parent = transform.parent;
        character = parent.gameObject.GetComponent<Character>();
        ChooseWeapon(level);
    }

    private void ChooseWeapon(int weaponNum)
    {
        int number = 0;
        foreach (Transform child in transform)
        {
            if (number == level)
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);

            number++;
        }
        SetStats();
    }

    public override void IncreaseLvl()
    {
        level++;
        ChooseWeapon(level);
    }

    public override void SetStats()
    {
        float damageByWeapon = (float)level / 2;
        character.damageModifier = damageByWeapon;
        character.ModifyCharacterDamage();
    }
}
