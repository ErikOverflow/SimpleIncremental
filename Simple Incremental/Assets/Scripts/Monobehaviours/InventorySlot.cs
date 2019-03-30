using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    ItemInstance item = null;
    [SerializeField]
    Image image = null;
    [SerializeField]
    Image emptySlot = null;
    [SerializeField]
    GameEvent itemEquipped = null;
    [SerializeField]
    GameEvent itemConsumed = null;

    public void Clicked()
    {
        if (item != null)
        {
            if (item is EquipmentInstance equipment)
            {
                equipment.Use();
                itemEquipped.Raise();
            }
            else
            {
                item.Use();
                itemConsumed.Raise();
            }
        }
    }

    public void ClearSlot()
    {
        item = null;
        image.enabled = false;
        emptySlot.enabled = true;
    }

    public void CreateSlot(ItemInstance _item)
    {
        if (_item?.item != null)
        {
            item = _item;
            image.enabled = true;
            image.sprite = item.item.sprite;
            emptySlot.enabled = false;
        }
        else
        {
            ClearSlot();
            PlayerInventory.instance.items.Remove(_item);
        }
    }
}
