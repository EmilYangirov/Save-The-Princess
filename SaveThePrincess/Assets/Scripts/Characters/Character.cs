using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : HitableObject
{
    public float health, damage, speed, power, attackRadius, attackDelay;
    public float damageModifier, baseHealth, baseDamage;
    public float maxHealth;
    public Transform attackCenter;
    public LayerMask enemyLayers;
    protected Animator anim;
    protected Rigidbody2D rb;
    public GameObject[] drops;
    public int AttackAnimCount;
    public List<CharacterBar> chBars;

    protected bool flip;
    public bool itsAttack = false;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        ModifyCharacterStats();
    }

    public abstract void Walk();

    public virtual void FixedUpdate()
    {
        Walk();
    }

    public virtual void Attack()
    {
        if (!itsAttack)
        {
            int i = Random.Range(0, AttackAnimCount);
            anim.SetFloat("chAttack", i);
            anim.SetTrigger("attack");
            //check hitted enemies
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackCenter.position, attackRadius, enemyLayers);
            //hit enemies
            foreach (Collider2D enemy in hitEnemies)
            {
                //check enemy position dir
                int enemyDirKoeff = 1;
                if (transform.position.x - enemy.transform.position.x > 0)
                {
                    enemyDirKoeff = -1;
                }
                //hit enemy
                enemy.transform.GetComponent<HitableObject>().Hit(damage, enemyDirKoeff, power);                
            }
            //attack wait
            StartCoroutine(ReloadCoroutine());
        }
    }

    public override void Hit(float getDamage, int dirKoeff, float enemyPower)
    {
        //hit animation
        anim.SetTrigger("hit");
        //-health
        health -= getDamage;
        //check HealthBar
        if (chBars.Count != 0)
        {
            CheckBars();
        }
        //push character
        rb.AddForce(Vector2.right * enemyPower * dirKoeff);
        //check death
        if (health <= 0)
        {
            Death();
        }
        
    }

    public virtual void Death()
    {
        if (drops.Length != 0)
        {
            int randomDrop = Random.Range(0, drops.Length);
            Instantiate(drops[randomDrop], transform.position, Quaternion.identity);
        }
        StartCoroutine(DeathCoroutine());        
    }

    private IEnumerator DeathCoroutine()
    {
        float time = 0;
        while (time < 1f)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2 (0,0), 8*Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }        
        Destroy(gameObject);
    }

    protected IEnumerator ReloadCoroutine()
    {
        itsAttack = true;
        yield return new WaitForSeconds(attackDelay);
        itsAttack = false;
    }

    protected virtual void FlipCharacter()
    {
        Vector2 scaleVector = new Vector2(-1, 1);
        transform.localScale *= scaleVector;
        flip = !flip;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackCenter == null)
           return;
        
        // Display attack radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(attackCenter.position, attackRadius);
    }

    public void CheckBars()
    {
        for (int i = 0; i < chBars.Count; i++)
        {
            chBars[i].CheckBar();
        }
    }

    public void ModifyCharacterStats()
    {
        health = baseHealth;
        damage = baseDamage + damageModifier;
    }
}
