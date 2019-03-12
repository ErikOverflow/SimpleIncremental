using UnityEngine;

public static class AttackStatEnemy
{
    public static int GetCalculatedDamage(int min, int max)
    {
        // Add one to max to make the range inclusive of max integer value
        int damage = Random.Range(min, max + 1);

        return damage;
    }
}
