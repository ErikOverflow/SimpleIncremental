using UnityEngine;

public class PlayerWeaponHook : MonoBehaviour
{
    [SerializeField]
    GameObject weapon = null;

    PlayerWeaponRangedController playerWeaponRangedController = null;
    PlayerWeaponMeleeController playerWeaponMeleeController = null;
    SpriteRenderer spriteRenderer = null;

    public void Awake()
    {
        playerWeaponRangedController = GetComponent<PlayerWeaponRangedController>();
        playerWeaponMeleeController = GetComponent<PlayerWeaponMeleeController>();
        spriteRenderer = weapon.GetComponent<SpriteRenderer>();
    }

    public void Hook()
    {
        if (PlayerInventory.instance?.weapon != null)
        {
            HookWeapon(PlayerInventory.instance.weapon);
        }
    }

    private void HookWeapon(ItemInstance item)
    {
        playerWeaponRangedController.enabled = false;
        playerWeaponMeleeController.enabled = false;
        if (item.item is WeaponRanged weaponRanged)
        {
            playerWeaponRangedController.damage = weaponRanged.damage;
            playerWeaponRangedController.falloffTime = weaponRanged.falloffTime;
            playerWeaponRangedController.maxHits = weaponRanged.maxHits;
            playerWeaponRangedController.projectileLaunchForce = weaponRanged.projectileLaunchForce;
			playerWeaponRangedController.projectileTorque = weaponRanged.projectileTorque;
            playerWeaponRangedController.projectileSprite = weaponRanged.projectileSprite;
            spriteRenderer.sprite = weaponRanged.sprite;
            playerWeaponRangedController.enabled = true;
        }
        else if (item.item is WeaponMelee weaponMelee)
        {
            playerWeaponMeleeController.damage = weaponMelee.damage;
            spriteRenderer.sprite = weaponMelee.sprite;
            playerWeaponMeleeController.enabled = true;
            playerWeaponMeleeController.weapon = weapon;
        }
    }
}