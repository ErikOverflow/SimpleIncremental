using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgradePanel : UIPanel
{
    [SerializeField]
    Transform slotsParent = null;

    UIUpgradeSlot[] slots;

    public override void Awake()
    {
        base.Awake();
        slots = slotsParent.GetComponentsInChildren<UIUpgradeSlot>();
    }

    public override void UpdateUI()
    {
        base.UpdateUI();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < PlayerUpgrades.instance.upgrades.Count)
            {
                slots[i].CreateSlot(PlayerUpgrades.instance.upgrades[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
