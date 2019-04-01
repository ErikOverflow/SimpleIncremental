using System;

[System.Serializable]
public class Equipment : Item
{
    public override void AddToInventory()
    {
        PlayerInventory.instance.AddItemToInventory(new ItemInstance(this));
    }
}