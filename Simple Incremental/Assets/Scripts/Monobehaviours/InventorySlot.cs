using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    ItemInstance item = null;
    [SerializeField]
    Image image = null;

    public void Clicked()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void ClearSlot()
    {
        item = null;
        image.enabled = false;
    }

    public void CreateSlot(ItemInstance _item)
    {
        if (_item != null)
        {
            item = _item;
            image.enabled = true;
            image.overrideSprite = item.item?.sprite;
        }
        else
        {
            ClearSlot();
            PlayerInventory.instance.items.Remove(_item);
        }
    }
}
