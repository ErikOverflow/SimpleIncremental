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
    EnemyScaling enemyScaling = null;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
        movement = GetComponent<Movement>();
        enemyScaling = GetComponent<EnemyScaling>();
    }

    public bool Hook()
    {
        if (enemyTemplate != null)
        {
            if (enemyScaling != null)
                enemyScaling.SetScale(enemyTemplate.gateJump, enemyTemplate.ramp, enemyTemplate.gate);
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
