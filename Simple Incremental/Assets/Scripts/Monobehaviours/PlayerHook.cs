using UnityEngine;

public class PlayerHook : MonoBehaviour
{
    [SerializeField]
    PlayerTemplate playerTemplate = null;
    CharacterHealth characterHealth = null;
    WeaponHook weaponHook = null;

    public void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        weaponHook = GetComponentInChildren<WeaponHook>();
    }

    public void Hook()
    {
        characterHealth.maxHealth = playerTemplate.health;
        weaponHook.SetDefaultWeapon(playerTemplate.defaultWeapon);
    }
}