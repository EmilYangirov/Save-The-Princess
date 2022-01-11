using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAgressive : Neutral
{
    public float runSpeed;
    public float walkSpeed;
    
    public new void Update()
    {
        base.Update();
        Attack();
    }
    public override void Hit(float getDamage, int dirKoeff, float enemyPower)
    {
        base.Hit(getDamage, dirKoeff, enemyPower);
        rb.AddForce(Vector2.up * enemyPower);
        agression = true;
        speed = runSpeed; 
    }
    
}
