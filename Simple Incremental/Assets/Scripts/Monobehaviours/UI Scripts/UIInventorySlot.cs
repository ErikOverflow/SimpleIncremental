using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    ItemInstance item = null;
    [SerializeField]
    Image image = null;

    public void Clicked()
    {
        item?.Use();
    }

    public void ClearSlot()
    {
        item = null;
        image.enabled = false;
    }

    public void CreateSlot(ItemInstance _item)
    {
        item = _item;
        image.enabled = true;
        image.overrideSprite = item.item.sprite;
    }
}
