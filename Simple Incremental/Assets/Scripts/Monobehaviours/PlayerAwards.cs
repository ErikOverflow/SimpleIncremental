using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwards : MonoBehaviour
{
    public int coins = 0;

    public void Start()
    {
        coins = DataController.gameData.coins;
    }

    public void GainCoins(int amount)
    {
        coins += amount;
    }

    public void LootEnemy(GameObject go)
    {
        CharacterLoot cl = go.GetComponent<CharacterLoot>();
        if(cl != null)
            GainCoins(cl.coins);
    }
}
