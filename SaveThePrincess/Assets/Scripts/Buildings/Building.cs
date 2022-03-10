using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : LevelSystem
{
    protected int cost;
    protected PlayerMoneys pMoney;

    protected string name;
    public Text nameText, costText;

    public virtual void Start()
    {
        cost = 50;

        for (int i = 0; i < level; i++)
        {
            cost = cost * 2;
        }

        pMoney = (PlayerMoneys)FindObjectOfType(typeof(PlayerMoneys));
        SetStats();
    }        

    public override void IncreaseLvl()
    {
        bool check = pMoney.CheckMoneys(cost);
        if (check && level < maxLevel)
        {                       
            pMoney.Buy(cost);
            level++;
            SetStats();
        }
    }


    public override void SetStats()
    {                
        cost = cost * 2;
        
        if(level < maxLevel)
            costText.text = "New level: " + cost;
        else
            costText.text = "Max level";

        nameText.text = name + ", level: " + level;
        
    }
}
