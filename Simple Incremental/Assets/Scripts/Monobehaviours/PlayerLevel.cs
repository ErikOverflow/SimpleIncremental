using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public static PlayerLevel instance;
    public int level = 1;
    public int experience = 0;
    public int nextLevelExp = 100;

    public event Action OnLevelUp;
    public event Action OnExperienceGained;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void LevelUp()
    {
        level++;
        OnLevelUp?.Invoke();
    }

    public void GainExperience(int amount)
    {
        nextLevelExp = level * 100;
        experience += amount;
        if (experience >= nextLevelExp)
        {
            int remainingExp = experience - nextLevelExp;
            experience = 0;
            LevelUp();
            GainExperience(remainingExp);
        }
        OnExperienceGained?.Invoke();
    }
}
