using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleByLevel : StatAugment
{
    CharacterHealth characterHealth = null;
    PlayerLevel playerLevel = null;
    PlayerWeaponRangedController playerWeaponRangedController = null;
    PlayerWeaponMeleeController playerWeaponMeleeController = null;

    public override void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        playerLevel = GetComponent<PlayerLevel>();
        playerWeaponRangedController = GetComponentInChildren<PlayerWeaponRangedController>();
        playerWeaponMeleeController = GetComponentInChildren<PlayerWeaponMeleeController>();
    }

    public override void Augment()
    {
        float multiplier = playerLevel.level;
        characterHealth.maxHealth = Mathf.CeilToInt(characterHealth.maxHealth * multiplier);
        playerWeaponRangedController.damage = Mathf.CeilToInt(playerWeaponRangedController.damage * multiplier);
        playerWeaponMeleeController.damage = Mathf.CeilToInt(playerWeaponMeleeController.damage * multiplier);
        characterHealth.ResetHealth();
    }
}
