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
    public float moveSpeed = 1f;
}
