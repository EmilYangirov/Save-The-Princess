using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    public FloatingJoystick fJoystick;

    public UnityEvent OnDeath;

    [HideInInspector] public float foods;     

    public override void Start()
    {
        base.Start();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    public override void Attack()
    {       
        base.Attack();        
    }
    public override void Walk()
    {
        if (fJoystick.Horizontal > 0.1 || fJoystick.Horizontal < -0.1)
        {
            anim.SetBool("run", true);
            FlipCharacter();
            rb.AddForce(Vector2.right * Mathf.Sign(fJoystick.Horizontal) * speed * Time.deltaTime);
            base.Walk();
        } else
        {
            anim.SetBool("run", false);
        }
    }

    protected override void FlipCharacter()
    {        
        if (fJoystick.Horizontal > 0.1)
        {
            if (flip)
            {
                base.FlipCharacter();
            }
        }
        if (fJoystick.Horizontal < -0.1)
        {           
            if (!flip)
            {
                base.FlipCharacter();
            }
        }
    }

    public override void Death()
    {
        OnDeath.Invoke();
        transform.position = new Vector2(1000, 1000);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
