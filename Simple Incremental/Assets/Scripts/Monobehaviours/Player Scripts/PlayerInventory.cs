using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public Action OnInventoryChange;

    public List<ItemInstance> items = null;
    [NonSerialized]
    public WeaponInstance weapon = null; //Nonserialized to avoid weapon instance being defined but not actually having values

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            items = new List<ItemInstance>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void Consume(ItemInstance item)
    {
        //Consume item
        items.Remove(item);
        OnInventoryChange?.Invoke();
    }

    public void EquipItem(EquipmentInstance equipment)
    {
        throw new EquipmentTypeUndefined();
    }

    public void UnEquipItem(EquipmentInstance equipment)
    {
        throw new EquipmentTypeUndefined();
    }

    public void EquipItem(WeaponInstance _weapon)
    {
        if(weapon != null)
            items.Add(weapon);
        weapon = _weapon;
        items.Remove(_weapon);
        OnInventoryChange?.Invoke();
    }

    public void UnEquipItem(WeaponInstance _weapon)
    {
        weapon = null;
        items.Add(_weapon);
        OnInventoryChange?.Invoke();
    }

    public void AddItemToInventory(ItemInstance item)
    {
        items.Add(item);
        //OnInventoryChange?.Invoke();
    }
}

public class EquipmentTypeUndefined : Exception { }