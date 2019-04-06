using UnityEngine;

public class EnemyHook : MonoBehaviour
{
    public EnemyTemplate enemyTemplate = null;
    SpriteRenderer spriteRenderer = null;
    CharacterHealth characterHealth = null;
    CharacterLoot characterLoot = null;
    EnemyMovement enemyMovement = null;
    EnemyAttackRanged enemyAttackRanged = null;
    EnemyAttackMelee enemyAttackMelee = null;
    EnemyExperience enemyExperience = null;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttackRanged = GetComponentInChildren<EnemyAttackRanged>();
        enemyAttackMelee = GetComponentInChildren<EnemyAttackMelee>();
        enemyExperience = GetComponent<EnemyExperience>();
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
            {
                characterLoot.coins = enemyTemplate.coins;
                characterLoot.items = enemyTemplate.lootableItems;
                characterLoot.lootChance = enemyTemplate.lootChance;
            }
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
            if(enemyExperience != null)
            {
                enemyExperience.experience = enemyTemplate.experience;
            }
            return true;
        }
        return false;
    }
}