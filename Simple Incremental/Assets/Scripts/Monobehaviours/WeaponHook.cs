using UnityEngine;

public class WeaponHook : MonoBehaviour
{
    [HideInInspector]
    public EquipmentInstance equipmentInstance = null;
    [Header("Default \"Unequipped\" Template")]
    [SerializeField]
    Weapon defaultValues = null;

    WeaponRangedController weaponRangedController = null;

    public void Awake()
    {
        weaponRangedController = GetComponent<WeaponRangedController>();
    }

    public void Hook()
    {
        if (equipmentInstance.equipped)
        {
            if(equipmentInstance.item is Weapon weapon)
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
        if (weapon is WeaponRanged weaponRanged)
        {
            weaponRangedController.gameObject.SetActive(true);
            weaponRangedController.damage = weaponRanged.damage;
            weaponRangedController.falloffTime = weaponRanged.falloffTime;
            weaponRangedController.maxHits = weaponRanged.maxHits;
            weaponRangedController.projectileSpeed = weaponRanged.projectileSpeed;
            weaponRangedController.projectileSprite = weaponRanged.projectileSprite;
        }
    }
}