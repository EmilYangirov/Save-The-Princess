using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Neutral : Enemy
{
    protected bool agression;
    public float timeInPosition;
    private bool onPoint;


    public new void Start()
    {
        base.Start();
        CreateTarget();
        ChooseTarget();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if(!agression && dist <= attackDist && !onPoint)
        {
            onPoint = true;
            StartCoroutine(WaitToChangeTarget());            
        }
        if (dist > walkDist)
            ChooseTarget();
        
        Attack();
    }
    //choose target in agressive mode or neutral
    public override void ChooseTarget()
    {
        if (!agression)
        {
            float newX = Random.Range(transform.position.x - walkDist, transform.position.x + walkDist);
            target.position = new Vector2(newX, transform.position.y);
            dist = Vector2.Distance(transform.position, target.position);
        } else
        {
            base.ChooseTarget();
        }
    }
    //create polint to target
    public void CreateTarget()
    {
        GameObject tarOb = new GameObject("target");        
        target = tarOb.transform;        
    }
    //wait time to change target position
    protected IEnumerator WaitToChangeTarget()
    {
        yield return new WaitForSeconds(timeInPosition);
        ChooseTarget();
        onPoint = false;
    }
    
    public override void Attack()
    {
        if (agression)
        {
            base.Attack();
        }
    }

    public override void Death()
    {
        if (!agression)
        {
            Destroy(target.gameObject);
        }
          
        base.Death();        
    }
}
