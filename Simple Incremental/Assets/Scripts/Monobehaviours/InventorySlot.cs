using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    ItemInstance item = null;
    [SerializeField]
    Image image = null;
    [SerializeField]
    TextMeshProUGUI equippedText = null;
    [SerializeField]
    Image emptySlot = null;
    [SerializeField]
    GameEvent itemClicked = null;

    public void Clicked()
    {
        if (item != null)
        {
            item.Use();
            itemClicked.Raise();
        }
    }

    public void ClearSlot()
    {
        item = null;
        image.enabled = false;
        equippedText.enabled = false;
        emptySlot.enabled = true;
    }

    public void CreateSlot(ItemInstance _item)
    {
        if (_item != null)
        {
            item = _item;
            image.enabled = true;
            image.sprite = item.item.sprite;
            //if (item is InventoryWeapon invWeap)
            //    equippedText.enabled = invWeap.equipped;
            //else
            equippedText.enabled = false;
            emptySlot.enabled = false;
        }
    }
}
