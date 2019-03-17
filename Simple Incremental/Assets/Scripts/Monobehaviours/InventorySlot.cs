using SimpleIncremental.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    InventoryItem item = null;
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
            if(item is InventoryWeapon invWeap)
                invWeap.equipped = !invWeap.equipped;
            if (item.template is HPPotionTemplate hpPotionTemplate)
                Debug.Log("Player healed: " + hpPotionTemplate.healAmount); //Implement item usage here
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

    public void CreateSlot(InventoryItem _item)
    {
        if (_item != null)
        {
            item = _item;
            image.enabled = true;
            image.sprite = item.template.sprite;
            if (item is InventoryWeapon invWeap)
                equippedText.enabled = invWeap.equipped;
            else
                equippedText.enabled = false;
            emptySlot.enabled = false;
        }
    }
}
