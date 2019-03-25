using System;
using UnityEngine;

[Serializable]
public abstract class ItemInstance
{
    public static ItemInstance GetItemInstance(Item _item)
    {
        if (_item is Equipment equip)
        {
            return new EquipmentInstance(equip);
        }
        else
        {
            return null;
        }
    }

    public Item item;

    public virtual void Use()
    {
        Debug.Log(item.itemName + " used.");
    }
}