using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelSystem : MonoBehaviour
{
    public int level;

    protected int maxLevel = 10;
    public abstract void IncreaseLvl();
    public abstract void SetStats();
}
