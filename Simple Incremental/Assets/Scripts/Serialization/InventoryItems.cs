using SimpleIncremental.Weapon;
using System;

namespace SimpleIncremental.Inventory
{
    [Serializable]
    public class InventoryWeapon
    {
        public WeaponTemplate template;
        public int level;
        public int experience;
        public bool equipped;
    }
}