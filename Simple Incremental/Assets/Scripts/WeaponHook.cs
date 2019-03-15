using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (projectileWeapon != null)
            {
                projectileWeapon.spriteRenderer.sprite = weaponTemplate.sprite;
                projectileWeapon.projectileSpeed = weaponTemplate.projectileSpeed;
                projectileWeapon.projectileSprite = weaponTemplate.projectileSprite;
                projectileWeapon.maxPenetrations = weaponTemplate.maxPenetrations;
                projectileWeapon.falloffTime = weaponTemplate.falloffTime;
                projectileWeapon.damage = weaponTemplate.damage;
                projectileWeapon.reloadSpeed = weaponTemplate.reloadSpeed;
            }
        }
        return false;
    }
}