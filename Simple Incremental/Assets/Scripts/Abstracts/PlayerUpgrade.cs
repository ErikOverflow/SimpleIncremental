using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUpgrade : StatAugment
{
    public int level = 0;
    public Sprite sprite = null;

    public void LevelUp()
    {
        level++;
    }
}
