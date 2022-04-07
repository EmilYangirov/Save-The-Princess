using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Building : LevelSystem
{
    protected int cost;
    protected PlayerMoneys pMoney;

    public TextMeshProUGUI nameText, costText;
    public UnityEvent OnGetMaxLevel;

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

        if (level < maxLevel)
        {
            costText.text = ": " + cost;
        } else
        {
            costText.text = "";
            OnGetMaxLevel.Invoke();
        }          

        nameText.text = ": "+ level;
        
    }
}
