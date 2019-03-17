using UnityEngine;

namespace SimpleIncremental.Inventory
{
    public abstract class ItemTemplate : ScriptableObject
    {
        public string itemName = "New Item";
        public Sprite sprite = null;
        public abstract InventoryItem GenerateNewItem();
    }

    [CreateAssetMenu]
    public class WeaponTemplate : ItemTemplate
    {
        public Type type = Type.Projectile;
        public Sprite projectileSprite = null;
        public float projectileSpeed = 1f;
        public int maxPenetrations = 1;
        public float falloffTime = 1f; //Time until the projectile disappears
        public float attackSpeed = 1f;
        public int damage = 1;

        public override InventoryItem GenerateNewItem()
        {
            return new InventoryWeapon
            {
                template = this,
                equipped = false,
                experience = 0,
                level = 1
            };
        }
    }

    [CreateAssetMenu]
    public class HPPotionTemplate : ItemTemplate
    {
        public int healAmount = 10;

        public override InventoryItem GenerateNewItem()
        {
            return new InventoryItem
            {
                template = this
            };
        }
    }
}


namespace SimpleIncremental.Inventory
{
    public enum Type
    {
        Projectile,
        Melee
    }
}
