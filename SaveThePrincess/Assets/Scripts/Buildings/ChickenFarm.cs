using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ChickenFarm : Building
{
    public GameObject[] SpawnGO;    
    private int chickenType = 0;
    public int ChickenCount;
    [HideInInspector]  public List<GameObject> SpawnedChickens;
    public int spawnTimer;
    private int timer;

    private bool ok = false;

    public override void Start()
    {
        name = "Chicken farm";        
        base.Start();
        timer = spawnTimer;
    }
    void Update()
    {
        GenerateChicken();
        CheckChicken();
    }
    private IEnumerator chickenGenerator()
    {
        yield return new WaitForSeconds(1);
        timer--;
        ok = false;
    }
    private void GenerateChicken()
    {
        if (!ok && SpawnedChickens.Count < ChickenCount)
        {
            StartCoroutine(chickenGenerator());
            ok = true;
        }
        if (timer == 0)
        {
            GameObject newChicken = Instantiate(SpawnGO[chickenType], transform.position, Quaternion.identity);
            SpawnedChickens.Add(newChicken);
            timer = spawnTimer;
        }       
    }
    private void CheckChicken()
    {
        foreach (GameObject chicken in SpawnedChickens.ToList())
        {
            if (chicken == null)
            {
                SpawnedChickens.Remove(chicken);
            }
        }
    }

    public override void SetStats()
    {
        base.SetStats();
        if (level >= 5)
        {
            chickenType = 1;
        }

        ChickenCount = level;
    }
}
