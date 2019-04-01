using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStatsSystem))]
[RequireComponent(typeof(CharacterLevel))]
public class EnemyScaleByLevel : StatAugment
{
    public float ramp = 0.1f;
    public int gate = 5;
    public float gateJump = 2f;

    CharacterHealth characterHealth = null;
    CharacterLoot characterLoot = null;
    CharacterLevel characterLevel = null;
    EnemyAttackRanged enemyAttackRanged = null;
    EnemyAttackMelee enemyAttackMelee = null;
    EnemyExperience enemyExperience = null;

    public override void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
        characterLevel = GetComponent<CharacterLevel>();
        enemyAttackRanged = GetComponent<EnemyAttackRanged>();
        enemyAttackMelee = GetComponent<EnemyAttackMelee>();
        enemyExperience = GetComponent<EnemyExperience>();
    }

    public override void Augment()
    {
        float multiplier = Mathf.Pow(gateJump, characterLevel.level / gate) * (1f + (characterLevel.level % gate) * ramp);
        characterHealth.maxHealth = Mathf.CeilToInt(characterHealth.maxHealth * multiplier);
        characterHealth.ResetHealth();
        characterLoot.coins = Mathf.CeilToInt(characterLoot.coins * multiplier);
        enemyAttackRanged.damage = Mathf.CeilToInt(enemyAttackRanged.damage * multiplier);
        enemyAttackMelee.damage = Mathf.CeilToInt(enemyAttackMelee.damage * multiplier);
        enemyExperience.experience = Mathf.CeilToInt(enemyExperience.experience * multiplier);
    }
}