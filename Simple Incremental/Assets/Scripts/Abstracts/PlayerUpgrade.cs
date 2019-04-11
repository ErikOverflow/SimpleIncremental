using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUpgrade : StatAugment
{
    public int level = 0;
    public Sprite sprite = null;
    public string upgradeName = null;
    public int cost = 10;

    public void LevelUp()
    {
        applied = true;
        level++;
    }
}
