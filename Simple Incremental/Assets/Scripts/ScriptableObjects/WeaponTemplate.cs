using UnityEngine;

namespace SimpleIncremental.Weapon
{
    [CreateAssetMenu]
    public class WeaponTemplate : ScriptableObject
    {
        public Type type = Type.Projectile;
        public Sprite sprite = null;
        public Sprite projectileSprite = null;
        public float projectileSpeed = 1f;
        public int maxPenetrations = 1;
        public float falloffTime = 1f; //Time until the projectile disappears
        public float attackSpeed = 1f;
        public int damage = 1;
    }
}


namespace SimpleIncremental.Weapon
{
    public enum Type
    {
        Projectile,
        Melee
    }
}
