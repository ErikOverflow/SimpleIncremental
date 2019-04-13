using UnityEngine;

public class PlayerWeaponHook : MonoBehaviour
{
    [SerializeField]
    GameObject weapon = null;

    [Header("Default \"Unequipped\" Template")]
    [SerializeField]
    Weapon defaultValues = null;

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
        else
        {
            HookWeapon(new ItemInstance(defaultValues));
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
            playerWeaponRangedController.projectileSpeed = weaponRanged.projectileSpeed;
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

    public void SetDefaultWeapon(Weapon weapon)
    {
        defaultValues = weapon;
    }
}