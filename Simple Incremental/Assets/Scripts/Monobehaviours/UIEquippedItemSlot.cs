using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEquippedItemSlot : MonoBehaviour
{
    EquipmentInstance item = null;
    [SerializeField]
    Image image = null;

    public void Clicked()
    {
        if (item != null)
        {
            item.UnEquip();
        }
    }

    public void ClearSlot()
    {
        item = null;
        image.enabled = false;
    }

    public void CreateSlot(EquipmentInstance _item)
    {
        item = _item;
        image.enabled = true;
        image.overrideSprite = item.item.sprite;
    }
}
