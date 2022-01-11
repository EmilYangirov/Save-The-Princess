using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntEnemy : Enemy
{
    public GameObject rangeAttackMissle;
    public Transform rangeAttackPosition;
    public AppleSpawner spawner;

    public new void Update()
    {
        base.Update();
        Attack();
    }
    public new void Attack()
    {
        if (dist >= walkDist && dist <= walkDist + 5)
        {
            if (!itsAttack)
            {
                anim.SetTrigger("anotherattack");
                StartCoroutine(ReloadCoroutine());
            }
        }
        else
        {
            base.Attack();
        }
    }
    //Play by event after range attack animation
    public void CreateMissle()
    {
        GameObject missle = Instantiate(rangeAttackMissle, rangeAttackPosition.position, Quaternion.identity);
        AttackBallistic AB = missle.GetComponent<AttackBallistic>();
        AB.targetPos = target.position;
    }
    public override void Hit(float getDamage, int dirKoeff, float enemyPower)
    {
        base.Hit(getDamage, dirKoeff, enemyPower);
        spawner.Hit();
    }
}
