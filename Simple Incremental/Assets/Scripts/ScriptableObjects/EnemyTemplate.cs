using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyTemplate : ScriptableObject
{
    public string enemyName = "New enemy";
    public Sprite sprite = null;
    public int health = 10;
    public int coins = 10;
    public int experience = 10;

    public float moveSpeed = 1f;
    public float responseTime = 1f;

    public Sprite projectileSprite = null;
    public int rangedDamage = 1;
    public float rangedFalloffTime = 3f;
    public float reloadTime = 1f;

    public int maxPenetrations = 1;
    public float projectileSpeed = 3f;
    public int meleeDamage = 1;
    public float meleePunchForce = 200f;

    public Item[] lootableItems = null;
    public float lootChance = 0.02f;
}
