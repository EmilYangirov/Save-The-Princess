using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : LevelSystem
{
    protected int level, cost;
    private PlayerMoneys pMoney;

    protected string name;
    public Text nameText, costText;

    public void Start()
    {
        cost = 50;
        pMoney = (PlayerMoneys)FindObjectOfType(typeof(PlayerMoneys));
        SetStats();
    }        

    public override void IncreaseLvl()
    {
        bool check = pMoney.CheckMoneys(cost);
        if (check)
        {                       
            pMoney.Buy(cost);
            cost *= 3;
            SetStats();
            level++;
        }
    }


    public override void SetStats()
    {
        nameText.text = name + ", level: " + level;
        costText.text = "New level: " + cost;
    }
}