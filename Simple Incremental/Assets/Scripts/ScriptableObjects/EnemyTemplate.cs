using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate : ScriptableObject
{
    public string enemyName = "New enemy";
    public Sprite basicSprite = null;
    public int health = 10;
    public int experience = 10;
    public float moveSpeed = 1f;
    public float responseTime = 1f;
    public Item[] lootableItems;

    //public Sprite sprite = null;

    //public Sprite projectileSprite = null;
    //public int rangedDamage = 1;
    //public float rangedFalloffTime = 3f;
    //public float reloadTime = 1f;
    //public int maxPenetrations = 1;
    //public float projectileSpeed = 3f;
    //public float projectileRotation = 20f;

    //public int meleeDamage = 1;
    //public float meleePunchForce = 200f;
}
