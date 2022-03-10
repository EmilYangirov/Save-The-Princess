using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : Building
{
    private AppleSpawner spawner;   

    public override void Start()
    {
        name = "Apple tree";        
        GameObject parent = transform.parent.gameObject;
        spawner = parent.GetComponent<AppleSpawner>();
        base.Start();       

    }

    public override void SetStats()
    {
        base.SetStats();
        if (level >= 5)
        {
            spawner.canSpawn = true;
            spawner.typeOfApple = 1;
        } 
        else 
        {            
            spawner.typeOfApple = 0;
        }

        spawner.maxAppleCount = level;
    }
}
