using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystem;
using UnityEngine.SceneManagement;

public class SceneInfo : MonoBehaviour
{
    [SerializeField]
    private LevelSystem[] levelObjects;

    private ChangeDayToNight dayAndNight;        
    private PlayerMoneys moneySystem;
    private Tower tower;

    [SerializeField]
    private List<SaveDataByLevels<float>> _healthOfTowers;
    [SerializeField]
    private List<SaveDataByLevels<int>> _currentDayOfLevels;
    [SerializeField]
    private List<SaveDataByLevels<int>> _levelsOfGameObjects;

    private string saveKey = "save";

       
    private void Awake()
    {        
        //find objects on scene
        levelObjects = FindObjectsOfType(typeof(LevelSystem)) as LevelSystem[];
        GameObject LevelManager = GameObject.FindGameObjectWithTag("levelmanager");
        dayAndNight = LevelManager.GetComponent<ChangeDayToNight>();
        GameObject character = GameObject.FindGameObjectWithTag("Character");
        moneySystem = character.GetComponent<PlayerMoneys>();
        GameObject tow = GameObject.FindGameObjectWithTag("tower");
        tower = tow.GetComponent<Tower>();
       
        //load save file
        Load();
    }

    private void Load()
    {
        //load data
        var data = SaveCreator.LoadData(saveKey);
        SaveData loadedData = JsonUtility.FromJson<SaveData>(data);
       
        if (loadedData != null)
        {
            //set arrays data
            _healthOfTowers = loadedData.healthOfTowers;
            _currentDayOfLevels = loadedData.currentDayOfLevels;
            _levelsOfGameObjects = loadedData.levelsOfGameObjects;
            string sceneName = SceneManager.GetActiveScene().name;
            
            //set moneys
            moneySystem.IncreaseMoneys(loadedData.money);

            //set towers health
            float currentHealth = GetValue<float>(_healthOfTowers, sceneName);
            if(currentHealth!=0)
                tower.health = GetValue<float>(_healthOfTowers, sceneName);
            
            //set current day
            dayAndNight.dayCount = GetValue<int>(_currentDayOfLevels, sceneName);
            
            //set levels to level systems
            foreach (LevelSystem levelSystems in levelObjects)
            {
                levelSystems.level = GetValue<int>(_levelsOfGameObjects, levelSystems.gameObject.name);
            }
        }

    }

    public void Save()
    {       
        SaveCreator.Save(saveKey, GetSaveSnapshot());
    }

    private SaveData GetSaveSnapshot()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        
        //change towers data        
        SaveDataByLevels<float> levelData = new SaveDataByLevels<float>(sceneName, tower.health);
        ChangeData<float>(_healthOfTowers, levelData);
        
        //change day data
        SaveDataByLevels<int> dayData = new SaveDataByLevels<int>(sceneName, dayAndNight.dayCount);
        ChangeData<int>(_currentDayOfLevels, dayData);
        
        //change levels system data
        foreach(LevelSystem levelSystems in levelObjects)
        {
            SaveDataByLevels<int> levelSystemData = new SaveDataByLevels<int>(levelSystems.gameObject.name, levelSystems.level);
            ChangeData<int>(_levelsOfGameObjects, levelSystemData);
        }
        
        //create data
        var data = new SaveData(moneySystem.moneys, _healthOfTowers, _currentDayOfLevels, _levelsOfGameObjects);                

        return data;
    }
     
    //change exist data in Lists
    private void ChangeData<T>(List<SaveDataByLevels<T>> data, SaveDataByLevels<T> element) 
    {
        foreach(SaveDataByLevels<T> elements in data)
        {
            if(elements.name == element.name)
            {
                data.Remove(elements);
                break;
            }
        }        
        
        data.Add(element);
    }

    //find  element in data to set parameters
    private T GetValue<T>(List<SaveDataByLevels<T>> data, string name)
    {
        foreach(SaveDataByLevels<T> elements in data)
        {
            if (elements.name == name)
                return elements.value;
        }
        return default(T);
    }

}