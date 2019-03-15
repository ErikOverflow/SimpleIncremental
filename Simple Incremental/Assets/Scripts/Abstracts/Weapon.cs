using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage = 1;
    public float attackSpeed = 1f;
    public abstract void Attack(Vector2 target);
}