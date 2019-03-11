using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHook : MonoBehaviour
{
    [SerializeField]
    private EnemyTemplate enemyTemplate = null;

    public void ChangeTemplate(EnemyTemplate enemyTemplate)
    {
        if (enemyTemplate != null)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            CharacterHealth characterHeatlh = GetComponent<CharacterHealth>();
            CharacterLoot characterLoot = GetComponent<CharacterLoot>();
            if(spriteRenderer != null)
                spriteRenderer.sprite = enemyTemplate.sprite;
            if(characterHeatlh != null)
                characterHeatlh.maxHealth = enemyTemplate.health;
            if(characterLoot != null)
                characterLoot.coins = enemyTemplate.coins;
        }
    }

    private void OnValidate()
    {
        ChangeTemplate(enemyTemplate);
    }
}
