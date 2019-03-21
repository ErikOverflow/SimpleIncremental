using UnityEngine;

namespace SimpleIncremental.Inventory
{
    public abstract class ItemTemplate : ScriptableObject
    {
        public Sprite itemSprite = null;
        public abstract InventoryItem GenerateNewItem();
    }
}
