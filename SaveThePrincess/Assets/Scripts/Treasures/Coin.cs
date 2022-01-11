using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Treasure
{
    private PlayerMoneys playerMoney;

    public override void GiveStats()
    {
        playerMoney = player.GetComponent<PlayerMoneys>();
        playerMoney.IncreaseMoneys((int)giveme);
    }
}
