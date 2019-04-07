using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeDamage : PlayerUpgrade
{
    WeaponRangedController wrc = null;
    WeaponMeleeController wmc = null;

    [SerializeField]
    float damageIncreasePerLevel = 0.2f;

    public override void Awake()
    {
        wrc = GetComponentInChildren<WeaponRangedController>();
        wmc = GetComponentInChildren<WeaponMeleeController>();
    }

    public override void Augment()
    {
        wrc.damage *= Mathf.CeilToInt(1 + level * damageIncreasePerLevel);
    }
}
