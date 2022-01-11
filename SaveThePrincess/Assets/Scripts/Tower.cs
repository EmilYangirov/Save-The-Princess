using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : HitableObject
{
    protected Animator anim;
    public float health, maxHealth;
    public CharacterBar healthBar;
    public GameObject[] treasures;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public override void Hit(float getDamage, int dirKoeff = 0, float enemyPower = 0)
    {
        health -= getDamage;
        healthBar.CheckBar();
        for (int i = 0; i < 5; i++)
        {
            int randomObject = Random.Range(0, treasures.Length);
            Instantiate(treasures[randomObject], new Vector2(transform.position.x, transform.position.y + 20),
                                                  Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        }
        anim.SetTrigger("hit");
    }   
}
