using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : LevelSystem
{
    public float maxX, minX;
    private ChangeDayToNight dayAndNight;
    public GameObject[] creaturesToSpawn;
    private Transform camera;
    private bool spawn = true;
    private float timeToSpawn = 8;
    private int creaturesIndex;
    
    
    private void Start()
    {
        camera = Camera.main.transform;
        GameObject LevelManager = GameObject.FindGameObjectWithTag("levelmanager");
        dayAndNight = LevelManager.GetComponent<ChangeDayToNight>();
        SetStats();
    }

    private void Update()
    {
        if (dayAndNight.dayCount % 3 == 0 && level != dayAndNight.dayCount / 3)
            IncreaseLvl();

       // if (spawn && dayAndNight.night)                       
            //SpawnCreatures();
    }

    public override void IncreaseLvl()
    {
        if (level < maxLevel)        
            level++;

        SetStats();
    }
    public override void SetStats()
    {
        if (level < maxLevel)
            creaturesIndex = level;
        else
            creaturesIndex = creaturesToSpawn.Length - 1;
    }

    private void SpawnCreatures()
    {
        Vector2 spawnPosition = SpawnPosition();
        int createCreature = Random.Range(0, creaturesIndex);
        Instantiate(creaturesToSpawn[createCreature], spawnPosition, Quaternion.identity);
        spawn = false;
        StartCoroutine(Timer());
    }

    private Vector2 SpawnPosition()
    {
        float x = Random.Range(minX, maxX);
        float cameraX = camera.position.x;
        
        while(x>cameraX - 30 && x < cameraX + 30)
            x = Random.Range(minX, maxX);

        float y = -10;
        return new Vector2(x, y);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToSpawn);
        spawn = true;
    }
}
