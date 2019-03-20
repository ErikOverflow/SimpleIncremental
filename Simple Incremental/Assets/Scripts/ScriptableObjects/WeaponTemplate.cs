using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleIncremental.Inventory
{
    public abstract class WeaponTemplate : ItemTemplate
    {
        public float attackSpeed = 1f;
        public int damage = 1;
    }
}