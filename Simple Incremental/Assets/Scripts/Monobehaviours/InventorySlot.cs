using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item = null;
    [SerializeField]
    Image image = null;
    [SerializeField]
    Image emptySlot = null;

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
        emptySlot.enabled = true;
    }

    public void CreateSlot(Item _item)
    {
        if (_item != null)
        {
            item = _item;
            image.enabled = true;
            image.sprite = item.sprite;
            emptySlot.enabled = false;
        }
        else
        {
            ClearSlot();
            PlayerInventory.instance.items.Remove(_item);
        }
    }
}
