using System;

namespace SimpleIncremental.Weapon
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