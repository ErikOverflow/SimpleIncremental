using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleIncremental.Inventory
{
    [CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Weapon Templates/Ranged weapon", order = 1)]
    public class RangedWeaponTemplate : WeaponTemplate
    {
        public Sprite projectileSprite = null;
        public float projectileSpeed = 1f;
        public int maxPenetrations = 1;
        public float falloffTime = 1f; //Time until the projectile disappears

        public override InventoryItem GenerateNewItem()
        {
            return new InventoryWeapon
            {
                weaponTemplate = this,
                equipped = false,
                experience = 0,
                level = 1
            };
        }
    }
}