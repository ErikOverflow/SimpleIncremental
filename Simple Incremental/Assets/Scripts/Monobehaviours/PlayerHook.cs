using UnityEngine;

public class PlayerHook : MonoBehaviour
{
    [SerializeField]
    PlayerTemplate playerTemplate = null;
    CharacterHealth characterHealth = null;

    public void Awake()
    {
        characterHealth = GetComponent<CharacterHealth>();
    }

    public void Hook()
    {
        characterHealth.maxHealth = playerTemplate.health;
    }
}
