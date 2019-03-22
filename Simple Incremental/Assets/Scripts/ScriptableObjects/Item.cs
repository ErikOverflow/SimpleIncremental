using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
}

public class Equipment : Item { }

public class Weapon : Equipment
{
    public int damage;
    public float attackSpeed;
}

[CreateAssetMenu]
public class WeaponRanged : Weapon
{
    public Sprite projectileSprite;
    public float projectileSpeed;
    public int maxHits;
    public float falloffTime;
}

[Serializable]
public class ItemInstance
{
    public Item item;

    public ItemInstance()
    {
        item = null;
    }

    public ItemInstance(Item _item)
    {
        item = _item;
    }

    public virtual void Use()
    {
        Debug.Log(item.name + " used.");
    }
}

[Serializable]
public class EquipmentInstance : ItemInstance
{
    public int level;
    public int experience;
    public bool equipped;

    public EquipmentInstance(Equipment _equipment)
    {
        item = _equipment;
        equipped = false;
    }

    public override void Use()
    {
        equipped = true;
    }
}