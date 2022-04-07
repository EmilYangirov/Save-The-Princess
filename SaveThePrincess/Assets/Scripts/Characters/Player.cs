using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField]
    private FloatingJoystick fJoystick;

    [SerializeField]
    private Button attackButton;

    private float horizontal;
    public UnityEvent OnDeath;
    [HideInInspector] public float foods;     

    public override void Start()
    {
        base.Start();

        if (!Application.isMobilePlatform && !Application.isEditor)
        {
            fJoystick.gameObject.SetActive(false);
            attackButton.gameObject.SetActive(false);
        }        
    }
    public override void FixedUpdate()
    {        
        if (!Application.isMobilePlatform)
        {
            horizontal = Input.GetAxis("Horizontal");



            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1) || Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1))
            {
                Attack();
            }

        } else
        {
            horizontal = fJoystick.Horizontal;
        }

        base.FixedUpdate();
    }
    
    public override void Walk()
    {
        if (horizontal > 0.1 || horizontal < -0.1)
        {
            anim.SetBool("run", true);
            FlipCharacter();
            rb.AddForce(Vector2.right * Mathf.Sign(horizontal) * speed * Time.deltaTime);
            base.Walk();
        } else
        {
            anim.SetBool("run", false);
        }
    }

    protected override void FlipCharacter()
    {        
        if (horizontal > 0.1)
        {
            if (flip)
            {
                base.FlipCharacter();
            }
        }
        if (horizontal < -0.1)
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
