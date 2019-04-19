using System;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public Sprite sprite;

    public abstract void AddToInventory();
}

[Serializable]
public abstract class ItemInstance
{
    [NonSerialized]
    public Item item;
    public string templateName;
    public string itemType;

    public ItemInstance(Item template)
    {
        if (template != null)
        {
            item = template;
            templateName = template.name;
        }
    }

    public abstract void Clicked();
}