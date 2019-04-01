using System;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public Sprite sprite;

    public virtual void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new ItemInstance(this));
    }
}

[Serializable]
public class ItemInstance
{
    public Item item;
    public string name;

    public int genericInt1;
    public int genericInt2;
    public int genericInt3;

    public ItemInstance(Item template)
    {
        if(template != null)
        {
            item = template;
            name = template.name;
        }
    }

    public void Use()
    {
        if(this.item is Equipment)
            PlayerInventory.instance.EquipWeapon(this);
    }
}