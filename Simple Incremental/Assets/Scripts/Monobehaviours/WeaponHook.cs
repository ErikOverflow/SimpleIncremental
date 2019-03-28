using UnityEngine;

public class WeaponHook : MonoBehaviour
{
    [Header("Default \"Unequipped\" Template")]
    [SerializeField]
    Weapon defaultValues = null;

    WeaponRangedController weaponRangedController = null;
    WeaponMeleeController weaponMeleeController = null;
    SpriteRenderer spriteRenderer = null;

    public void Awake()
    {
        weaponRangedController = GetComponent<WeaponRangedController>();
        weaponMeleeController = GetComponent<WeaponMeleeController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Hook()
    {
        if (PlayerInventory.instance?.weapon.item != null)
        {
            if(PlayerInventory.instance.weapon.item is Weapon weapon)
            {
                HookWeapon(weapon);
            }
            else
            {
                throw new System.Exception("Non-weapon was attached to the weapon hook");
            }
        }
        else
        {
            HookWeapon(defaultValues);
        }
    }

    private void HookWeapon(Weapon weapon)
    {
        weaponRangedController.enabled = false;
        weaponMeleeController.enabled = false;
        if (weapon is WeaponRanged weaponRanged)
        {
            weaponRangedController.damage = weaponRanged.damage;
            weaponRangedController.falloffTime = weaponRanged.falloffTime;
            weaponRangedController.maxHits = weaponRanged.maxHits;
            weaponRangedController.projectileSpeed = weaponRanged.projectileSpeed;
            weaponRangedController.projectileSprite = weaponRanged.projectileSprite;
            spriteRenderer.sprite = weaponRanged.sprite;
            weaponRangedController.enabled = true;
        }
        else if(weapon is WeaponMelee weaponMelee)
        {
            weaponMeleeController.damage = weaponMelee.damage;
            spriteRenderer.sprite = weaponMelee.sprite;
            weaponMeleeController.enabled = true;
        }
    }

    public void SetDefaultWeapon(Weapon weapon)
    {
        defaultValues = weapon;
    }
}