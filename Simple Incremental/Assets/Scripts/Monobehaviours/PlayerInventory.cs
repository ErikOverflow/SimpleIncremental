using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public Action OnItemEquipped;

    public List<ItemInstance> items = null;
    [NonSerialized]
    public ItemInstance weapon = null; //Nonserialized to avoid weapon instance being defined but not actually having values

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

    public void EquipWeapon(ItemInstance newWeapon)
    {
        if (newWeapon?.item is Weapon)
        {
            if (newWeapon == weapon)
            {
                items.Add(newWeapon);
                weapon = null;
            }
            else if(weapon != null)
            {
                int index = items.IndexOf(newWeapon);
                items.Insert(index, weapon);
                items.Remove(newWeapon);
                weapon = newWeapon;
            }
            else
            {
                weapon = newWeapon;
                items.Remove(newWeapon);
            }
            OnItemEquipped?.Invoke();
        }
    }

    public void AddItemToInventory(ItemInstance item)
    {
        items.Add(item);
    }
}