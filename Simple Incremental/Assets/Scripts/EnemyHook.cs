using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHook : MonoBehaviour
{
    [SerializeField]
    private EnemyTemplate enemyTemplate = null;

    SpriteRenderer spriteRenderer = null;
    CharacterHealth characterHealth = null;
    CharacterLoot characterLoot = null;
    Movement movement = null;
    EnemyScaling enemyScaling = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterHealth = GetComponent<CharacterHealth>();
        characterLoot = GetComponent<CharacterLoot>();
        movement = GetComponent<Movement>();
        enemyScaling = GetComponent<EnemyScaling>();
    }

    public void ChangeTemplate(EnemyTemplate enemyTemplate)
    {
        if (enemyTemplate != null)
        {
            if (spriteRenderer != null)
                spriteRenderer.sprite = enemyTemplate.sprite;
            if(characterHealth != null)
                characterHealth.maxHealth = enemyTemplate.health;
            if(characterLoot != null)
                characterLoot.coins = enemyTemplate.coins;
            if (movement != null)
                movement.moveSpeed = enemyTemplate.moveSpeed;
            if(enemyScaling != null)
            {
                enemyScaling.SetScale(enemyTemplate.gateJump, enemyTemplate.ramp, enemyTemplate.gate);
            }
        }
    }

    public void ScaleEnemy(float multiplier)
    {
        characterHealth.maxHealth = Mathf.FloorToInt(enemyTemplate.health * multiplier);
        characterLoot.coins = Mathf.FloorToInt(enemyTemplate.coins * multiplier);
    }

    private void OnValidate() //Enables use in editor
    {
        if (SceneManager.GetActiveScene().isLoaded)
        {
            Awake();
            ChangeTemplate(enemyTemplate);
        }
    }
}
