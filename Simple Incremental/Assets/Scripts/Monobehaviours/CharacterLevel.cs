using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevel : MonoBehaviour
{
    public int level;

    public event Action OnLevelUp;

    public void LevelUp()
    {
        level++;
        OnLevelUp?.Invoke();
    }
}
