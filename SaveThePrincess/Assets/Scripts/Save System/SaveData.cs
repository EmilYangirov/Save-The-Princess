using System.Collections.Generic;

namespace SaveSystem
{
    [System.Serializable]
    public class SaveData
    {
        public int money;

        public float characterLvlValue;

        public List<SaveDataByLevels<float>> healthOfTowers;

        public List<SaveDataByLevels<int>> currentDayOfLevels;

        public List<SaveDataByLevels<int>> levelsOfGameObjects;

        public SaveData(int _money, float _characterLvlValue,  
                                    List<SaveDataByLevels<float>> _healthOfTowers,
                                    List<SaveDataByLevels<int>> _currentDayOfLevels, 
                                    List<SaveDataByLevels<int>> _levelsOfGameObjects)
        {
            money = _money;
            characterLvlValue = _characterLvlValue;
            healthOfTowers = _healthOfTowers;
            currentDayOfLevels = _currentDayOfLevels;
            levelsOfGameObjects = _levelsOfGameObjects;
        }
               
    }

    [System.Serializable]
    public struct SaveDataByLevels <T>
    {
        public string name;
        public T value;

        public SaveDataByLevels(string _name, T _value)
        {
            name = _name;
            value = _value;
        }
    }
    
}

