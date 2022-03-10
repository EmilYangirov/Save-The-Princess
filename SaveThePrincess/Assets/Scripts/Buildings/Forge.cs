using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : Building
{
    private Weapons weaponScript;
    public override void Start()
    {        
        GameObject characterWeapons = GameObject.FindGameObjectWithTag("weapon");
        weaponScript = characterWeapons.GetComponent<Weapons>();
        name = "Forge";
        base.Start();        
    }

    public override void IncreaseLvl()
    {
        bool check = pMoney.CheckMoneys(cost);

        if (check && level < maxLevel)
        {
            pMoney.Buy(cost);
            level++;
            weaponScript.IncreaseLvl();
            SetStats();
        }
    }
}
