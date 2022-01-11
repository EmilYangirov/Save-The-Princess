using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBallistic : MonoBehaviour
{
    public float gravity_acceleration;
    public float start_angle;
    public float start_velocity;
    public Vector2 targetPos;
    public Vector2 startPos;
    public float timer;

    private void Start()
    {
        startPos = transform.position;
        start_velocity = (Mathf.Abs(targetPos.x - transform.position.x)/Mathf.Cos(start_angle))
            *Mathf.Sqrt(gravity_acceleration/(2*(Mathf.Tan(start_angle)
            * Mathf.Abs(targetPos.x - transform.position.x) - targetPos.y + transform.position.y)));
    }
    void Update()
    {        
        timer = timer + Time.deltaTime;
        int i = 1;
        if (startPos.x > targetPos.x)
        {
            i = -1;
        }
        transform.position = new Vector2(startPos.x + start_velocity * timer * Mathf.Cos(start_angle) * i,
                                        startPos.y + start_velocity * timer * Mathf.Sin(start_angle) 
                                        - gravity_acceleration * timer * timer / 2);
    }
    
}
