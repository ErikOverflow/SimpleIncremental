using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public static PlayerProgression instance;
    CharacterLevel characterLevel = null;

    int experienceForNextLevel;

    [SerializeField]
    GameEvent playerLevelUp = null;

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

    private void Start()
    {
        experienceForNextLevel = CalculateExperienceForNextLevel(characterLevel.level);
    }

    private int CalculateExperienceForNextLevel(int level)
    {
        return experienceForNextLevel = level * 100;
    }

    public void GainExperience(int amount)
    {
        int remainder = amount - experienceForNextLevel;
        experienceForNextLevel -= amount;
        if(experienceForNextLevel < 0)
        {
            playerLevelUp.Raise();
            GainExperience(-experienceForNextLevel);
        } else if( experienceForNextLevel == 0)
        {
            playerLevelUp.Raise();
            experienceForNextLevel = CalculateExperienceForNextLevel(characterLevel.level);
        }
    }
}
