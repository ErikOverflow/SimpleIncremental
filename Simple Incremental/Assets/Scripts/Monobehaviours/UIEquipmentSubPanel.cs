using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipmentSubPanel : UISubPanel
{
    [SerializeField]
    UIEquippedItemSlot weaponSlot = null;
    [SerializeField]
    TextMeshProUGUI levelText = null;
    [SerializeField]
    Slider expSlider = null;

    PlayerLevel playerLevel = null;

    public override void Awake()
    {
        base.Awake();
        playerLevel = UIBackpack.instance.player.GetComponent<PlayerLevel>();
    }

    public override void UpdateUI()
    {
        if (PlayerInventory.instance.weapon != null)
            weaponSlot.CreateSlot(PlayerInventory.instance.weapon);
        else
            weaponSlot.ClearSlot();

        expSlider.maxValue = playerLevel.nextLevelExp;
        expSlider.value = playerLevel.experience;
        levelText.text = "Level " + playerLevel.level.ToString();
    }
}
