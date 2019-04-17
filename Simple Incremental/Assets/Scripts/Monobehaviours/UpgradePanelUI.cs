using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelUI : PanelUI
{
    [SerializeField]
    Transform slotsParent = null;

    UpgradeSlot[] slots;
    PlayerLevel playerLevel = null;

    public override void Awake()
    {
        base.Awake();
        slots = slotsParent.GetComponentsInChildren<UpgradeSlot>();
    }

    public void Start()
    {
        playerLevel = BackpackUI.instance.player.GetComponent<PlayerLevel>();
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
