using SimpleIncremental.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    InventoryWeapon weapon = null;
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
        if (weapon != null)
        {
            weapon.equipped = !weapon.equipped;
            itemClicked.Raise();
        }
    }

    public void ClearSlot()
    {
        weapon = null;
        image.enabled = false;
        equippedText.enabled = false;
        emptySlot.enabled = true;
    }

    public void CreateSlot(InventoryWeapon _weapon)
    {
        if (_weapon != null)
        {
            weapon = _weapon;
            image.sprite = weapon.template.sprite;
            equippedText.enabled = weapon.equipped;
            emptySlot.enabled = false;
        }
    }
}
