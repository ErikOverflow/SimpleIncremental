using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Upgrade", menuName = "Player Upgrades/Damage Upgrade", order = 1)]
public class PlayerUpgradeDamage : PlayerUpgrade
{
    PlayerWeaponRangedController pwrc = null;
    PlayerWeaponMeleeController pwmc = null;

    [SerializeField]
    int damageIncrease = 5;

    public override void Augment(GameObject go)
    {
        pwrc = go.GetComponent<PlayerWeaponRangedController>();
        pwmc = go.GetComponent<PlayerWeaponMeleeController>();
        pwrc.damage += damageIncrease;
        pwmc.damage += damageIncrease;
    }
}
