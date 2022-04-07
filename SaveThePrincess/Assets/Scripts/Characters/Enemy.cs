using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected Transform target;
    public float attackDist, walkDist;
    protected float dist;

    protected Player player;
    public override void Start()
    {
        base.Start();

        GameObject ch = GameObject.FindGameObjectWithTag("Character");
        player = ch.GetComponent<Player>();

        ChooseTarget();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        dist = Vector2.Distance(transform.position, target.position);
        Attack();
    }
    public override void Walk()
    {        
        if (dist > attackDist && dist <= walkDist)
        {
            rb.AddForce(Vector2.right*Mathf.Sign(target.position.x - transform.position.x) * speed *Time.deltaTime);
            anim.SetBool("walk", true);
            base.Walk();
        } else 
        {
            anim.SetBool("walk", false);            
        }
        FlipCharacter();
    }

    public override void Attack()
    {
        if (dist <= attackDist)
        {
            base.Attack();
        }
    }

    protected override void FlipCharacter()
    {
        if (transform.position.x - target.position.x < 0 && flip)
        {
           base.FlipCharacter();          
        }
        if (transform.position.x - target.position.x > 0 && !flip)
        {
           base.FlipCharacter();            
        }
    }
    public virtual void ChooseTarget()
    {        
        target = player.transform;
    }
}
