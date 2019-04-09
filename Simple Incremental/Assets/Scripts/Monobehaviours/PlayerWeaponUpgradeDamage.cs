using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponUpgradeDamage : PlayerUpgrade
{
    PlayerWeaponRangedController pwrc = null;
    PlayerWeaponMeleeController pwmc = null;

    [SerializeField]
    float damageIncreasePerLevel = 0.2f;

    public override void Awake()
    {
        pwrc = GetComponent<PlayerWeaponRangedController>();
        pwmc = GetComponent<PlayerWeaponMeleeController>();
    }

    public override void Augment()
    {
        pwrc.damage *= Mathf.CeilToInt(1 + level * damageIncreasePerLevel);
    }
}
