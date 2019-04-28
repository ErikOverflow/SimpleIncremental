using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEquippedUpgradesSubPanel : UISubPanel
{
    public static UIEquippedUpgradesSubPanel instance;
    [SerializeField]
    Transform equippedSlotsParent = null;
    [SerializeField]
    GameObject equippedUpgradeSlotPrefab = null;

    UIEquippedUpgradeSlot[] equippedUpgradeSlots = null;

    public override void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            base.Awake();
            instance = this;
        }
    }

    public void EquipUpgrade(PlayerUpgrade upgrade, UIEquippedUpgradeSlot slot)
    {
        PlayerUpgrades.instance.EquipUpgrade(upgrade, Array.FindIndex(equippedUpgradeSlots, w=> w==slot));
    }

    private void Start()
    {
        PlayerUpgrades.instance.UpgradesChanged += UpdateUI;
        equippedUpgradeSlots = new UIEquippedUpgradeSlot[PlayerUpgrades.instance.equippedUpgrades.Length];
        for (int i = 0; i < equippedUpgradeSlots.Length; i++)
        {
            GameObject go = ObjectPooler.instance.GetPooledObject(equippedUpgradeSlotPrefab);
            go.transform.SetParent(equippedSlotsParent);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            equippedUpgradeSlots[i] = go.GetComponentInChildren<UIEquippedUpgradeSlot>();
        }
    }

    public override void UpdateUI()
    {
        for (int i = 0; i < equippedUpgradeSlots.Length; i++)
        {
            equippedUpgradeSlots[i].CreateSlot(PlayerUpgrades.instance.equippedUpgrades[i]);
        }
    }
}
