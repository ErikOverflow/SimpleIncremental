using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelUI : PanelUI
{
    [SerializeField]
    Transform slotsParent = null;
    [SerializeField]
    InventorySlot weaponSlot = null;

    InventorySlot[] slots;

    public override void ClosePanel()
    {
        throw new System.NotImplementedException();
    }

    public override void OpenPanel()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < PlayerInventory.instance.items.Count)
            {
                slots[i].CreateSlot(PlayerInventory.instance.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
        if (PlayerInventory.instance.weapon != null)
            weaponSlot.CreateSlot(PlayerInventory.instance.weapon);
        else
            weaponSlot.ClearSlot();
    }
}
