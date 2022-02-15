using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : Building
{
    private AppleSpawner spawner;   

    public override void Start()
    {
        name = "Apple tree";
        GameObject apple = GameObject.FindWithTag("AppleTree");
        spawner = apple.GetComponent<AppleSpawner>();
        base.Start();       
        spawner.maxAppleCount = 1;

    }

    public override void SetStats()
    {
        base.SetStats();
        if (level >= 5)
        {
            spawner.canSpawn = true;
        }
        else
        {
            spawner.maxAppleCount++;
        }
    }
}
