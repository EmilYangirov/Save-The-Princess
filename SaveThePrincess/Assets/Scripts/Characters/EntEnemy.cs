using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntEnemy : RangeEnemy
{
    
    public AppleSpawner spawner;
    
    [HideInInspector]
    public AppleSpawner creatorSpawner;
   
   
    public override void Hit(float getDamage, int dirKoeff, float enemyPower)
    {
        base.Hit(getDamage, dirKoeff, enemyPower);
        spawner.Hit();
    }
}
