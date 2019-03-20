using UnityEngine;

namespace SimpleIncremental.Inventory
{
    [CreateAssetMenu(fileName = "New Health Potion", menuName = "Item Templates/Health Potion", order = 1)]
    public class HealthPotionTemplate : ItemTemplate
    {
        public int healAmount = 10;

        public override InventoryItem GenerateNewItem()
        {
            return new InventoryHealthPotion
            {
                healthPotionTemplate = this
            };
        }
    }
}