using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    [SerializeField]
    GameEvent itemEquipped = null;
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
            else if (newWeapon == null)
            {
                weapon = newWeapon;
                items.Remove(newWeapon);
            }
            else if(weapon != null)
            {
                items.Add(weapon);
                weapon = newWeapon;
                items.Remove(newWeapon);
            }
            else
            {
                weapon = newWeapon;
                items.Remove(newWeapon);
            }
            itemEquipped.Raise();
        }
    }

    public void AddItemToInventory(ItemInstance item)
    {
        items.Add(item);
    }
}