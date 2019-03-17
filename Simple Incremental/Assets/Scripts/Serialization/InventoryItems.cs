using SimpleIncremental.Weapon;
using System;

namespace SimpleIncremental.Inventory
{
    [Serializable]
    public class InventoryItem
    {
        public ItemTemplate template;
    }

    [Serializable]
    public class InventoryWeapon : InventoryItem
    {
        public new WeaponTemplate template;
        public int level;
        public int experience;
        public bool equipped;
    }
}