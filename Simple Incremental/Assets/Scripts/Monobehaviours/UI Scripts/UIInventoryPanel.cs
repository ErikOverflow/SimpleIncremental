using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPanel : UIPanel
{
    [SerializeField]
    Transform slotsParent = null;
    bool dirty = true;
    UIInventorySlot[] slots;

    public override void Awake()
    {
        base.Awake();
        slots = slotsParent.GetComponentsInChildren<UIInventorySlot>();
    }

    public void Start()
    {
        PlayerInventory.instance.OnInventoryChange += SetDirty;
        PlayerInventory.instance.OnItemUsed += UpdateUI;
    }

    private void SetDirty()
    {
        dirty = true;
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
        dirty = false;
    }

    private void OnBecameVisible()
    {
        if (dirty)
            UpdateUI();
    }
}
