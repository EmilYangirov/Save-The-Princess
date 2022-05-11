using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urlbut : MonoBehaviour
{
    private string url;

    [SerializeField]
    private string ruUrl, enUrl;
    private void Start()
    {
        if (Localization.selectedLanguage == 1)
            url = ruUrl;
        else
            url = enUrl;        
    }

    public void OnClick()
    {
        Application.OpenURL(url);
    }

}
