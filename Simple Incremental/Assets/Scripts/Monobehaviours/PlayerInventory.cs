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
    //[HideInInspector] //Polymorphism doesn't play nice with the inspector, so this isn't the place to maintain item inventory from the editor.
    public List<Item> items = null;
    public int totalItemsCollected = 0;
    public Weapon weapon = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            items = new List<Item>();
            weapon = null; //This needs to be set to null, because public variables in the inspector UNDO the null set above. 
        }
        else
        {
            Destroy(this);
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        if (newWeapon != null)
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
            else
            {
                items.Add(weapon);
                weapon = newWeapon;
                items.Remove(newWeapon);
            }
            itemEquipped.Raise();
        }
    }

    public void AddItemToInventory(Item item)
    {
        totalItemsCollected++;
        items.Add(item);
    }
}