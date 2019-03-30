using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStatsSystem))]
[RequireComponent(typeof(CharacterLevel))]
public class PlayerScaleByLevel : StatAugment
{
    CharacterHealth characterHealth = null;
    CharacterLevel characterLevel = null;
    WeaponRangedController weaponRangedController = null;
    WeaponMeleeController weaponMeleeController = null;

    public override void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        characterLevel = GetComponent<CharacterLevel>();
        weaponRangedController = GetComponentInChildren<WeaponRangedController>();
        weaponMeleeController = GetComponentInChildren<WeaponMeleeController>();
    }

    public override void Augment()
    {
        float multiplier = characterLevel.level + 1;
        characterHealth.maxHealth = Mathf.CeilToInt(characterHealth.maxHealth * multiplier);
        weaponRangedController.damage = Mathf.CeilToInt(weaponRangedController.damage * multiplier);
        weaponMeleeController.damage = Mathf.CeilToInt(weaponMeleeController.damage * multiplier);
        characterHealth.ResetHealth();
    }
}