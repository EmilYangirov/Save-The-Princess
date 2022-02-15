using UnityEngine;

public static class SaveCreator
{
    public static void Save(string key, SaveSystem.SaveData saveData)
    {
        string jsonDataString = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(key, jsonDataString);
    }

    public static string LoadData(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string loadedString = PlayerPrefs.GetString(key);
            return(loadedString);
        } else 
            return null;        
    }

}
