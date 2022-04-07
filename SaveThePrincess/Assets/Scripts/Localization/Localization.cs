using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Localization : MonoBehaviour
{
    public static int selectedLanguage { get; private set; }


    public delegate void LanguageChangeHandler();
    public static event LanguageChangeHandler OnLanguageChange;

    private static Dictionary<string, List<string>> localization;

    [SerializeField]
    private TextAsset textFile;

    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
            selectedLanguage = 1;
        else
            selectedLanguage = 0;
        
        if (localization == null)
            LoadLocalization();
    }

    private void LoadLocalization()
    {
        localization = new Dictionary<string, List<string>>();

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(textFile.text);

        foreach(XmlNode key in xmlDocument["keys"].ChildNodes)
        {
            string keyString = key.Attributes["Name"].Value;

            var values = new List<string>();
            foreach(XmlNode translate in key["Translates"].ChildNodes)
                values.Add(translate.InnerText);

            localization[keyString] = values;
        }

    }

    public static string GetTranslate(string key, int languageId = -1)
    {
        if (languageId == -1)
            languageId = selectedLanguage;

        if (localization.ContainsKey(key))
            return localization[key][languageId];

        return key;
    }

    public void SetLanguage(int id)
    {
        selectedLanguage = id;
        OnLanguageChange?.Invoke();
    }
}
