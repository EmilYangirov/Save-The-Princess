using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBallistic : MonoBehaviour
{
    
    [SerializeField]
    private float startAngle, gravityAcceleration;

    private float startVelocity;

    [HideInInspector]
    public Vector2 targetPos;

    private Vector2 startPos;
    private float timer;

    private void Start()
    {
        startPos = transform.position;
        startAngle = Mathf.PI * startAngle / 180;
        startVelocity = Mathf.Sqrt((Vector2.Distance(startPos, targetPos) * gravityAcceleration) / Mathf.Sin(2 * startAngle));      
    }
    private void Update()
    {
        timer = timer + Time.deltaTime;
        int i = 1;
        if (startPos.x > targetPos.x)
        {
            i = -1;
        }
        transform.position = MisslePosition(i);

        Debug.Log(transform.position);
    }

    private Vector2 MisslePosition(int xKoeff)
    {
        float x = startPos.x + startVelocity * timer * Mathf.Cos(startAngle) * xKoeff;
        float y = startPos.y + (startVelocity * Mathf.Sin(startAngle) * timer) - (gravityAcceleration * timer * timer / 2);
        Vector2 newPos = new Vector2(x, y);
        return newPos;
    }

}
