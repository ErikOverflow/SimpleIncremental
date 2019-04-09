using UnityEngine;

public class PlayerHook : MonoBehaviour
{
    [SerializeField]
    PlayerTemplate playerTemplate = null;
    CharacterHealth characterHealth = null;
    PlayerWeaponHook playerWeaponHook = null;

    public void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
        playerWeaponHook = GetComponentInChildren<PlayerWeaponHook>();
    }

    public void Hook()
    {
        characterHealth.maxHealth = playerTemplate.health;
        playerWeaponHook.SetDefaultWeapon(playerTemplate.defaultWeapon);
    }
}