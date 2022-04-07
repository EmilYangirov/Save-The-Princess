using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField]
    private GameObject rangeAttackMissle;
    [SerializeField]
    private Transform rangeAttackPosition;
    [SerializeField]
    private float rangeAttackDist;
    [SerializeField]
    private AudioClip rangeAttack;

    public override void Attack()
    {
        if (dist >= rangeAttackDist - 5 && dist <= rangeAttackDist + 10)
        {
            if (!itsAttack)
            {
                anim.SetTrigger("anotherattack");
                attackPlayer.PlaySound(rangeAttack);
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
        if (dist < rangeAttackDist-5 || dist > rangeAttackDist + 10)
        {
            base.Walk();
        }
        else
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
}
