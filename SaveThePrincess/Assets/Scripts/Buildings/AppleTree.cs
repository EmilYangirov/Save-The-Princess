using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : Building
{
    private AppleSpawner spawner;   

    public override void Start()
    {      
        GameObject parent = transform.parent.gameObject;
        spawner = parent.GetComponent<AppleSpawner>();
        base.Start();
    }

    public override void SetStats()
    {
        base.SetStats();
                
        if (level >= 5)
        {
            spawner.PrepareToSpawn();
            spawner.typeOfApple = 2;
        } 

        if(level >= 3 && level < 5)
            spawner.typeOfApple = 1;
        
        if(level < 3)
            spawner.typeOfApple = 0;

        spawner.maxAppleCount = level;
    }
}
