using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatsSystem))]
public class EnemyLevelAugment : StatAugment
{
    public int level = 1;

    float ramp = 1f;
    int gate = 1;
    float gateJump = 1f;

    CharacterHealth characterHealth = null;
    CharacterLoot characterLoot = null;

    public override void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
    }

    public void SetScale(float _amount, float _ramp, int _gate)
    {
        gateJump = _amount;
        ramp = _ramp;
        gate = _gate;
    }

    public override void Augment()
    {
        float multiplier = Mathf.Pow(gateJump, level / gate) * (1f + (level % gate) * ramp);
        characterHealth.maxHealth = Mathf.CeilToInt(characterHealth.maxHealth * multiplier);
        characterHealth.ReCalculateHealth();
        characterLoot.coins = Mathf.CeilToInt(characterLoot.coins * multiplier);
    }
}