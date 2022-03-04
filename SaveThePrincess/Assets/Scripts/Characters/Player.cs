using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Character
{
    public FloatingJoystick fJoystick;
    private ChangeUISize endScreen;

    [HideInInspector] public float foods;     

    public override void Start()
    {
        base.Start();
        endScreen = GetComponent<ChangeUISize>();
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
        endScreen.CloseAndShowUiElement();
        base.Death();
    }

}
