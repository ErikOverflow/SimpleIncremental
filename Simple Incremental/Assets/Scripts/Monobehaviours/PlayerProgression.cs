using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public static PlayerProgression instance;
    CharacterLevel characterLevel = null;

    int experienceForNextLevel = 100;
    int currentExperience = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        characterLevel = GetComponent<CharacterLevel>();
    }

    public void GainExperience(int amount)
    {
        experienceForNextLevel = characterLevel.level * 100;
        currentExperience += amount;
        if(currentExperience >= experienceForNextLevel)
        {
            int remainingExp = currentExperience - experienceForNextLevel;
            currentExperience = 0;
            characterLevel.LevelUp();
            GainExperience(remainingExp);
        }
    }
}
