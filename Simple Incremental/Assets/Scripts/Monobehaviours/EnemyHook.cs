using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHook : MonoBehaviour
{
    [SerializeField]
    EnemyTemplate enemyTemplate = null;
    SpriteRenderer spriteRenderer = null;
    CharacterHealth characterHealth = null;
    CharacterLoot characterLoot = null;
    Movement movement = null;
    EnemyLevelAugment enemyLevelAugment = null;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
        movement = GetComponent<Movement>();
        enemyLevelAugment = GetComponent<EnemyLevelAugment>();
    }

    public bool Hook()
    {
        if (enemyTemplate != null)
        {
            if (spriteRenderer != null)
                spriteRenderer.sprite = enemyTemplate.sprite;
            if (characterHealth != null)
            {
                characterHealth.maxHealth = enemyTemplate.health;
                characterHealth.ResetHealth();
            }
            if (characterLoot != null)
                characterLoot.coins = enemyTemplate.coins;
            if (movement != null)
                movement.moveSpeed = enemyTemplate.moveSpeed;
            return true;
        }
        return false;
    }
}