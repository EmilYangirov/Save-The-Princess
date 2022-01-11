using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitableObject : MonoBehaviour
{
    public abstract void Hit(float getDamage, int dirKoeff, float enemyPower);
}
