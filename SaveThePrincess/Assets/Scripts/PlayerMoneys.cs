using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneys : MonoBehaviour
{
    private int moneys;
    public Text moneyText;
    public string moneyString;
    
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
        moneyText.text = moneyString + moneys;
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
