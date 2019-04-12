using UnityEngine;

public class WeaponHook : MonoBehaviour
{
    [Header("Default \"Unequipped\" Template")]
    [SerializeField]
    Weapon defaultValues = null;

    WeaponRangedController weaponRangedController = null;
    WeaponMeleeController weaponMeleeController = null;
    [SerializeField]
    GameObject weapon = null;
    SpriteRenderer spriteRenderer = null;

    public void Awake()
    {
        weaponRangedController = GetComponent<WeaponRangedController>();
        weaponMeleeController = GetComponent<WeaponMeleeController>();
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
        weaponRangedController.enabled = false;
        weaponMeleeController.enabled = false;
        if (item.item is WeaponRanged weaponRanged)
        {
            weaponRangedController.damage = weaponRanged.damage;
            weaponRangedController.falloffTime = weaponRanged.falloffTime;
            weaponRangedController.maxHits = weaponRanged.maxHits;
            weaponRangedController.projectileSpeed = weaponRanged.projectileSpeed;
            weaponRangedController.projectileRotation = weaponRanged.projectileRotation;
            weaponRangedController.projectileSprite = weaponRanged.projectileSprite;
            spriteRenderer.sprite = weaponRanged.sprite;
            weaponRangedController.enabled = true;
        }
        else if (item.item is WeaponMelee weaponMelee)
        {
            weaponMeleeController.damage = weaponMelee.damage;
            spriteRenderer.sprite = weaponMelee.sprite;
            weaponMeleeController.enabled = true;
            weaponMeleeController.weapon = weapon;
        }
    }

    public void SetDefaultWeapon(Weapon weapon)
    {
        defaultValues = weapon;
    }
}