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
        if (level < maxLevel)
            weaponScript.IncreaseLvl();

        base.IncreaseLvl();        
    }
}
