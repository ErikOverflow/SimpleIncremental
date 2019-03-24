using System;
using UnityEngine;

[Serializable]
public class ItemInstance
{
    public Item item;

    public virtual void Use()
    {
        Debug.Log(item.itemName + " used.");
    }
}