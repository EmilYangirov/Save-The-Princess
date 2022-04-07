using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Neutral
{
    [SerializeField]
    protected float runSpeed;
    [SerializeField]
    protected float walkSpeed;
    [SerializeField]
    private GameObject[] lowHpDrops;

    public override void Hit(float getDamage, int dirKoeff, float enemyPower)
    {        
        base.Hit(getDamage, dirKoeff, enemyPower);
        rb.AddForce(Vector2.up* enemyPower);
        StartCoroutine(WaitToChangeRunToWalk());
        Run();
    }

    private IEnumerator WaitToChangeRunToWalk()
    {
        yield return new WaitForSeconds(5);
        anim.SetFloat("chWalk", 0);
        speed = walkSpeed;
        walkDist = walkDist / 2;
    }

    private void Run()
    {        
        anim.SetFloat("chWalk", 1);
        speed = runSpeed;
        walkDist = walkDist * 2;        
    }

    protected override GameObject[] ChooseDropsArray()
    {
        if (player.health < player.maxHealth)
        {       
            return lowHpDrops;
        } else
        {
            return base.ChooseDropsArray();
        } 
    }
}
