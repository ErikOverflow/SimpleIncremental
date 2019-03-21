using SimpleIncremental.Inventory;
using SimpleIncremental.Weapon;
using UnityEngine;

public class WeaponHook : MonoBehaviour
{
    public WeaponTemplate weaponTemplate = null;
    //ProjectileWeapon projectileWeapon = null;

    public void Awake()
    {
        //projectileWeapon = GetComponent<ProjectileWeapon>();
    }

    public bool Hook()
    {
        if (weaponTemplate != null)
        {
            //if(weaponTemplate is RangedWeaponTemplate projectileTemplate)
            //{
            //    projectileWeapon.active = true;
            //    projectileWeapon.spriteRenderer.sprite = projectileTemplate.itemSprite;
            //    projectileWeapon.projectileSpeed = projectileTemplate.projectileSpeed;
            //    projectileWeapon.projectileSprite = projectileTemplate.projectileSprite;
            //    projectileWeapon.maxPenetrations = projectileTemplate.maxPenetrations;
            //    projectileWeapon.falloffTime = projectileTemplate.falloffTime;
            //    projectileWeapon.damage = projectileTemplate.damage;
            //    projectileWeapon.attackSpeed = projectileTemplate.attackSpeed;
            //    return true;
            //}
        }
        return false;
    }
}