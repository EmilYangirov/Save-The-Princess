using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthBar : CharacterBar
{
    private Tower tower;
    private void Awake()
    {
        tower = gameObject.GetComponent<Tower>();
        maxValue = tower.maxHealth;
        value = tower.health;
        CreateBar();
        CheckBar();
    }

    public override void CheckBar()
    {
        maxValue = tower.maxHealth;
        value = tower.health;
        base.CheckBar();
    }
}

