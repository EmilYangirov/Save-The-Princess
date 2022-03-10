using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : Building, IHitableObject
{
    protected Animator anim;
    public float health, maxHealth;
    public CharacterBar healthBar;
    public GameObject[] treasures;

    [SerializeField]
    private AudioClip[] hitAudio;

    private SoundPlayer soundPlayer;

    public UnityEvent OnDeath;
    public override void Start()
    {
        soundPlayer = new SoundPlayer(gameObject);
        anim = gameObject.GetComponent<Animator>();
    }
    public void Hit(float getDamage, int dirKoeff = 0, float enemyPower = 0)
    {
        health -= getDamage;
        healthBar.CheckBar();
        for (int i = 0; i < 5; i++)
        {
            int treasureQuality = TreasureQuality(getDamage);
            int randomObject = Random.Range(0, treasureQuality);
            Instantiate(treasures[randomObject], new Vector2(transform.position.x, transform.position.y + 20),
                                                  Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        }

        if(health <= 0)
        {
            Death();
        }
        anim.SetTrigger("hit");
        soundPlayer.PlaySound(hitAudio);
    }   
    
    private int TreasureQuality(float getDamage)
    {
        if (getDamage <= treasures.Length)
            return (int)System.Math.Ceiling(getDamage);
        else
            return treasures.Length;
    }

    private void Death()
    {
        OnDeath.Invoke();
    }
}
