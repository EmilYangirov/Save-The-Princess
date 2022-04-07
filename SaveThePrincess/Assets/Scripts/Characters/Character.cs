using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHitableObject
{
    public float health, damage, speed, power, attackRadius, attackDelay;
    public float damageModifier, baseDamage;
    public float maxHealth;

    [SerializeField]
    private int timeToChangeWalkSound = 0;

    public Transform attackCenter;
    public LayerMask enemyLayers;
    protected Animator anim;
    protected Rigidbody2D rb;
    public GameObject[] drops;
    public int AttackAnimCount;
    public List<CharacterBar> chBars;

    [SerializeField]
    protected AudioClip[] walkSounds, attackSound, hitSound;

    protected SoundPlayer walkPlayer, attackPlayer, hitPlayer;

    protected bool flip;
    public bool itsAttack = false;
    private bool itsDead = false;

    protected Character()
    {
        chBars = new List<CharacterBar>();
    }
    public virtual void Start()
    {
        //create sound players
        walkPlayer = new SoundPlayer(gameObject);
        attackPlayer = new SoundPlayer(gameObject);
        hitPlayer = new SoundPlayer(gameObject);

        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        health = maxHealth;
        ModifyCharacterDamage();
        CheckBars();
    }

    public virtual void Walk()
    {
        //Play Sound
        walkPlayer.PlaySound(walkSounds, timeToChangeWalkSound);
    }
    public virtual void FixedUpdate()
    {
        Walk();
    }

    public virtual void Attack()
    {
        if (!itsAttack && !itsDead)
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
                enemy.transform.GetComponent<IHitableObject>().Hit(damage, enemyDirKoeff, power);                
            }
            //attack wait
            StartCoroutine(ReloadCoroutine());
            //Play Sound
            attackPlayer.PlaySound(attackSound);
        }
    }

    public virtual void Hit(float getDamage, int dirKoeff, float enemyPower)
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
            StartCoroutine(DeathCoroutine());
        }
        Debug.Log(getDamage);
        //Play Sound
        hitPlayer.PlaySound(hitSound);
    }

    public virtual void Death()
    {        
        Destroy(gameObject);
    }

    protected void CreateDrop()
    {
        var dropsArray = ChooseDropsArray();

        if (dropsArray.Length != 0 && dropsArray != null)
        {
            int randomDrop = Random.Range(0, dropsArray.Length);
            Instantiate(dropsArray[randomDrop], transform.position, Quaternion.identity);
        }
    }
    protected virtual GameObject[] ChooseDropsArray()
    {
        return drops;
    }
    private IEnumerator DeathCoroutine()
    {
        itsDead = true;
        CreateDrop();
        float time = 0;
        while (time < 1f)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2 (0,0), 8*Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
        Death();
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

    public void ModifyCharacterDamage()
    {
        damage = baseDamage + damageModifier;
        CheckBars();
    } 
    
    public void IncreaseHealth(float value)
    {
        if (health + value <= maxHealth)
            health += value;
        else
            health = maxHealth;

        CheckBars();
    }    
}
