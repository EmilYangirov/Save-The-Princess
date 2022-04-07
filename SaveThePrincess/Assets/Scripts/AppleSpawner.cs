using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour, IHitableObject
{
    public List<Transform> apples;
    public GameObject[] spawnGO;
    public GameObject[] treasureGO;
    public Collider2D spawnArea;
    public float timeToSpawn, maxAppleCount;
    public bool canSpawn;
    public GameObject ent;
    private GameObject spawnedTree;
    private bool spawn=true, dead;
    private Animator anim;
    public int typeOfApple = 0;
    private int timerToSpawn = 60;

    private Coroutine spawnApplesTimer;

    [SerializeField]
    private AudioClip[] hitAudio;

    private SoundPlayer soundPlayer;

    private void Start()
    {
        soundPlayer = new SoundPlayer(gameObject);
        anim = GetComponent<Animator>();
    }
    public static Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }

    private void Update()
    {
        if(!dead)
            SpawnApples();
        else if (spawnedTree == null)
            ComeToAlive();
    }

    private void SpawnApples()
    {
        if (spawn && apples.Count < maxAppleCount)
        {
            Vector2 randomSpawn = RandomPointInBounds(spawnArea.bounds);
            GameObject newapple = Instantiate(spawnGO[typeOfApple], randomSpawn, Quaternion.identity);
            newapple.transform.SetParent(spawnArea.transform);
            apples.Add(newapple.transform);
            spawn = false;
            spawnApplesTimer = StartCoroutine(Timer());            
        }
    }

    public void Hit(float getDamage=0, int dirKoeff=0, float enemyPower=0)
    {
        anim.SetTrigger("hit");
        for (int i = 0; i < apples.Count; i++)
        {
            GameObject newapple = Instantiate(treasureGO[typeOfApple], apples[i].position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            Destroy(apples[i].gameObject);            
        }
        apples.Clear();
        StopCoroutine(spawnApplesTimer);
        spawnApplesTimer = StartCoroutine(Timer());

        if (canSpawn)
            anim.SetBool("dead", true);

        soundPlayer.PlaySound(hitAudio);
    }
    public void ComeToAlive()
    {
        dead = false;             
        anim.SetBool("dead", false);
        PrepareToSpawn();
        spawnApplesTimer = StartCoroutine(Timer());
        
    }
    private void SpawnEnt()
    {
        dead = true;       
        StopAllCoroutines();       
        spawnedTree = Instantiate(ent, transform.position, Quaternion.identity);
        spawn = false;        
    }
  
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToSpawn);
        spawn = true;
    }

    public void PrepareToSpawn()
    {
        canSpawn = false;
        timerToSpawn = 60;
        StartCoroutine(ChangeTimeToSpawnEnt());
    }
    private IEnumerator ChangeTimeToSpawnEnt()
    {
        yield return new WaitForSeconds(1);
        timerToSpawn--;

        if (timerToSpawn <= 0)
            canSpawn = true;
        else
            StartCoroutine(ChangeTimeToSpawnEnt());
    }
}
