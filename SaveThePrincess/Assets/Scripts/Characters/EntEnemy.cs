using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntEnemy : Enemy
{
    public GameObject rangeAttackMissle;
    public Transform rangeAttackPosition;
    public AppleSpawner spawner;

    [SerializeField]
    private float rangeAttackDist;
    
    [HideInInspector]
    public AppleSpawner creatorSpawner;

    public new void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Attack()
    {
        if (dist >= rangeAttackDist && dist <= rangeAttackDist + 10)
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

    public override void Walk()
    {
        if (dist < rangeAttackDist || dist > rangeAttackDist + 10)
        {
            base.Walk();
        } else
        {
            anim.SetBool("walk", false);
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
