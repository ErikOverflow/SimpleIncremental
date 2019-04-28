using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExperience : MonoBehaviour
{
    public int experience = 0;

    CharacterHealth characterHealth = null;

    private void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
    }

    private void Start()
    {
        characterHealth.OnDeath += DeliverExperience;
    }

    private void DeliverExperience()
    {
        PlayerLevel.instance.GainExperience(experience);
    }
}
