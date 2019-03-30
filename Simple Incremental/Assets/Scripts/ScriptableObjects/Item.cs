using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public Item original;
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

    public static T ScriptableInstantiate<T>(T original) where T : Item
    {
        T newObj = Instantiate(original);
        newObj.original = original;
        return newObj;
    }
}