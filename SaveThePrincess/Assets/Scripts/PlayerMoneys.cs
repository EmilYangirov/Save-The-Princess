using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneys : MonoBehaviour
{
    public int moneys { get; private set; }
    public TextMeshProUGUI moneyText;
    
    private void Start()
    {
        CheckMoneysText();
    }

    public void IncreaseMoneys(int money)
    {
        moneys += money;
        CheckMoneysText();
    }

    public void Buy(int money)
    {
        moneys -= money;
        CheckMoneysText();
    }

    private void CheckMoneysText()
    {
        if(moneyText!= null)
            moneyText.text = ": "+moneys;
    }

    public bool CheckMoneys(int money)
    {
        if(moneys >= money)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
