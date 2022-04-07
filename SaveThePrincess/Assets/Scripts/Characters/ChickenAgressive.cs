using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAgressive : Chicken
{   
    public override void Hit(float getDamage, int dirKoeff, float enemyPower)
    {        
        rb.AddForce(Vector2.up * enemyPower);
        agression = true;
        base.Hit(getDamage, dirKoeff, enemyPower);
        speed = runSpeed; 
    }
    
}
