using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Neutral
{
    public float runSpeed;
    public float walkSpeed;

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
        StopCoroutine(WaitToChangeTarget());
        anim.SetFloat("chWalk", 1);
        speed = runSpeed;
        walkDist = walkDist * 2;
        ChooseTarget();
    }

}
