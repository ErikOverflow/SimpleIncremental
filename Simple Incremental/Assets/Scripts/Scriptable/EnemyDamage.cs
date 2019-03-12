using UnityEngine;

[CreateAssetMenu]
public class EnemyDamage : ScriptableObject
{
    [SerializeField]
    public  int minDamage;

    [SerializeField]
    public int maxDamage;

    [SerializeField]
    public float attackRange;

    [SerializeField]
    public float attackCooldown;

    float damagePerSecond;

    public void CalculateDamagePerSecond()
    {
        damagePerSecond = (maxDamage - minDamage) / attackCooldown;
    }

    public float GetDamagePerSecond()
    {
        return damagePerSecond;
    }
}
