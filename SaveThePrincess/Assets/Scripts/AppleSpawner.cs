using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour, IHitableObject
{
    public List<Transform> apples;
    public GameObject spawnGO;
    public GameObject treasureGO;
    public Collider2D spawnArea;
    public float timeToSpawn, maxAppleCount;
    public bool canSpawn;
    public GameObject ent;
    private bool spawn=true;

    public static Vector2 RandomPointInBounds(Bounds bounds)
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }

    private void Update()
    {
        SpawnApples();
    }

    private void SpawnApples()
    {
        if (spawn && apples.Count < maxAppleCount)
        {
            Vector2 randomSpawn = RandomPointInBounds(spawnArea.bounds);
            GameObject newapple = Instantiate(spawnGO, randomSpawn, Quaternion.identity);
            newapple.transform.SetParent(spawnArea.transform);
            apples.Add(newapple.transform); 
            StartCoroutine(Timer());
            spawn = false;
        }
    }

    public void Hit(float getDamage=0, int dirKoeff=0, float enemyPower=0)
    {
        for (int i = 0; i < apples.Count; i++)
        {
            GameObject newapple = Instantiate(treasureGO, apples[i].position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            Destroy(apples[i].gameObject);            
        }
        apples.Clear();
        StopAllCoroutines();
        spawn = true;
        spawnEnt();
    }
    private void spawnEnt()
    {
        if (canSpawn)
        {
            Instantiate(ent, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToSpawn);
        spawn = true;
    }
}
