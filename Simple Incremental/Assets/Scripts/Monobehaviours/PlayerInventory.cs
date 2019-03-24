using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    [HideInInspector] //Polymorphism doesn't play nice with the inspector, so this isn't the place to maintain item inventory from the editor.
    public List<ItemInstance> items = new List<ItemInstance>();
    public EquipmentInstance weapon = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            weapon = null; //This needs to be set to null, because public variables in the inspector UNDO the null set above. 
        }
        else
        {
            Destroy(this);
        }
    }

    public void EquipWeapon(EquipmentInstance equipmentInstance)
    {
        if(weapon == equipmentInstance)
        {
            items.Add(weapon);
            weapon = null;
        }
        else if (weapon == null)
        {
            weapon = equipmentInstance;
            items.Remove(equipmentInstance);
        }
        else
        {
            items.Add(weapon);
            weapon = equipmentInstance;
            items.Remove(equipmentInstance);
        }
    }
}
