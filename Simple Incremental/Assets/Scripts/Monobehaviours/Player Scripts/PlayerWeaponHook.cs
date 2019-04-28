using UnityEngine;

public class PlayerWeaponHook : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer weaponRenderer = null;
    [SerializeField]
    Transform throwingHand = null;
    [SerializeField]
    Collider2D meleeHitbox = null;

    PlayerWeaponRangedController playerWeaponRangedController = null;
    PlayerWeaponMeleeController playerWeaponMeleeController = null;

    public void Awake()
    {
        playerWeaponRangedController = GetComponent<PlayerWeaponRangedController>();
        playerWeaponMeleeController = GetComponent<PlayerWeaponMeleeController>();
        playerWeaponRangedController.throwingHand = throwingHand;
        playerWeaponMeleeController.weaponCollider = meleeHitbox;
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
            weaponRenderer.sprite = weaponRanged.sprite;
            playerWeaponRangedController.enabled = true;
        }
        else if (item.item is WeaponMelee weaponMelee)
        {
            playerWeaponMeleeController.damage = weaponMelee.damage;
            weaponRenderer.sprite = weaponMelee.sprite;
            playerWeaponMeleeController.enabled = true;
        }
    }
}