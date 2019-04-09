using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatsSystem))]
[RequireComponent(typeof(CharacterLevel))]
public class PlayerScaleByLevel : StatAugment
{
    CharacterHealth characterHealth = null;
    CharacterLevel characterLevel = null;
    PlayerWeaponRangedController playerWeaponRangedController = null;
    PlayerWeaponMeleeController playerWeaponMeleeController = null;

    public override void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        characterLevel = GetComponent<CharacterLevel>();
        playerWeaponRangedController = GetComponentInChildren<PlayerWeaponRangedController>();
        playerWeaponMeleeController = GetComponentInChildren<PlayerWeaponMeleeController>();
    }

    public override void Augment()
    {
        float multiplier = characterLevel.level;
        characterHealth.maxHealth = Mathf.CeilToInt(characterHealth.maxHealth * multiplier);
        playerWeaponRangedController.damage = Mathf.CeilToInt(playerWeaponRangedController.damage * multiplier);
        playerWeaponMeleeController.damage = Mathf.CeilToInt(playerWeaponMeleeController.damage * multiplier);
        characterHealth.ResetHealth();
    }
}