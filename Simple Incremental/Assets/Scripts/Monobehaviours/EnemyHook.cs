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
    EnemyMovement enemyMovement = null;
    EnemyAttackRanged enemyAttackRanged = null;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttackRanged = GetComponent<EnemyAttackRanged>();
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
            if (enemyMovement != null)
            {
                enemyMovement.moveSpeed = enemyTemplate.moveSpeed;
                enemyMovement.responseTime = enemyTemplate.responseTime;
            }                
            if(enemyAttackRanged != null)
            {
                enemyAttackRanged.projectileSprite = enemyTemplate.projectileSprite;
                enemyAttackRanged.damage = enemyTemplate.rangedDamage;
                enemyAttackRanged.falloffTime = enemyTemplate.rangedFalloffTime;
                enemyAttackRanged.maxPenetrations = enemyTemplate.maxPenetrations;
                enemyAttackRanged.projectileSpeed = enemyTemplate.projectileSpeed;
            }
            return true;
        }
        return false;
    }
}