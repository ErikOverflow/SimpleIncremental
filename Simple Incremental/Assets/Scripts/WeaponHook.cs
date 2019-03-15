using SimpleIncremental.Weapon;
using UnityEngine;

[RequireComponent(typeof(ProjectileWeapon))]
public class WeaponHook : MonoBehaviour
{
    [SerializeField]
    WeaponTemplate weaponTemplate = null;
    ProjectileWeapon projectileWeapon = null;

    public void Awake()
    {
        projectileWeapon = GetComponent<ProjectileWeapon>();
    }

    public bool Hook()
    {
        if (weaponTemplate != null)
        {
            if(weaponTemplate.type == Type.Projectile)
            {
                projectileWeapon.gameObject.SetActive(true);
                projectileWeapon.spriteRenderer.sprite = weaponTemplate.sprite;
                projectileWeapon.projectileSpeed = weaponTemplate.projectileSpeed;
                projectileWeapon.projectileSprite = weaponTemplate.projectileSprite;
                projectileWeapon.maxPenetrations = weaponTemplate.maxPenetrations;
                projectileWeapon.falloffTime = weaponTemplate.falloffTime;
                projectileWeapon.damage = weaponTemplate.damage;
                projectileWeapon.attackSpeed = weaponTemplate.attackSpeed;
                return true;
            }
        }
        return false;
    }
}