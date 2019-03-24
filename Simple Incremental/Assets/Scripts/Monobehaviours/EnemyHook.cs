using UnityEngine;

public class EnemyHook : MonoBehaviour
{
    [SerializeField]
    EnemyTemplate enemyTemplate = null;
    SpriteRenderer spriteRenderer = null;
    CharacterHealth characterHealth = null;
    CharacterLoot characterLoot = null;
    EnemyMovement enemyMovement = null;
    EnemyAttackRanged enemyAttackRanged = null;
    EnemyAttackMelee enemyAttackMelee = null;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttackRanged = GetComponent<EnemyAttackRanged>();
        enemyAttackMelee = GetComponent<EnemyAttackMelee>();
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
                enemyAttackRanged.reloadTime = enemyTemplate.reloadTime;
            }
            if(enemyAttackMelee != null)
            {
                enemyAttackMelee.damage = enemyTemplate.meleeDamage;
                enemyAttackMelee.punchForce = enemyTemplate.meleePunchForce;
            }
            return true;
        }
        return false;
    }
}