using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelSystem : MonoBehaviour
{
    public int level;
    public int id;
    public abstract void IncreaseLvl();
    public abstract void SetStats();
}
