using UnityEngine;
using UnityEngine.UI;

public class TextLocalization : MonoBehaviour
{
    private Text text;
    private string key;

    private void Start()
    {
        Localize();
        Localization.OnLanguageChange += OnLanguageChange;
    }

    private void OnLanguageChange()
    {
        Localize();
    }
    private void Init()
    {
        text = GetComponent<Text>();
        key = text.text;
    }

    public void Localize(string newKey = null)
    {
        if (text == null)
            Init();
        else
            key = newKey;

        text.text = Localization.GetTranslate(key);
    }

    private void OnDestroy()
    {
        Localization.OnLanguageChange -= OnLanguageChange;
    }
}
