using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelSystem : MonoBehaviour
{
    public int level;

    [SerializeField]
    protected int maxLevel;
    public abstract void IncreaseLvl();
    public abstract void SetStats();
}
