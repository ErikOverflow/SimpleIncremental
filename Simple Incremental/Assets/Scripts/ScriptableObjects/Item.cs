using System;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public string itemName;
    public Sprite sprite;

    public virtual void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(ScriptableInstantiate(this));
    }

    public virtual void Use()
    {
        Debug.Log(itemName + " usage not implemented.");
    }

    public string GetSerialized()
    {
        return JsonUtility.ToJson(this);
    }

    public static T ScriptableInstantiate<T>(T original) where T : Item
    {
        T newObj = Instantiate(original);
        return newObj;
    }
}