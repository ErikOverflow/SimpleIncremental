using SimpleIncremental.Weapon;
using System;

namespace SimpleIncremental.Inventory
{
    [Serializable]
    public abstract class InventoryItem
    {
        abstract public ItemTemplate baseItemTemplate {get;}
        public abstract void Use();
    }

    [Serializable]
    public class InventoryWeapon : InventoryItem
    {
        public WeaponTemplate weaponTemplate;
        public int level;
        public int experience;
        public bool equipped;

        public override ItemTemplate baseItemTemplate
        {
            get { return weaponTemplate; }
        }

        public override void Use()
        {
            equipped = !equipped;
        }
    }

    [Serializable]
    public class InventoryHealthPotion : InventoryItem
    {
        public HealthPotionTemplate healthPotionTemplate;

        public override void Use()
        {
            //Do nothing right now
        }

        public override ItemTemplate baseItemTemplate
        {
            get
            {
                return healthPotionTemplate;
            }
        }
    }
}