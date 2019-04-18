using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelUI : PanelUI
{
    [SerializeField]
    Transform slotsParent = null;

    InventorySlot[] slots;
    PlayerLevel playerLevel = null;

    public override void Awake()
    {
        base.Awake();
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void Start()
    {
        playerLevel = BackpackUI.instance.player.GetComponent<PlayerLevel>();
        PlayerInventory.instance.OnItemEquipped += UpdateUI;
    }

    public override void UpdateUI()
    {
        base.UpdateUI();
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
    }
}
