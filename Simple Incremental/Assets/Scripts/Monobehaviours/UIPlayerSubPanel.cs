using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerSubPanel : SubPanelUI
{
    [SerializeField]
    InventorySlot weaponSlot = null;
    [SerializeField]
    TextMeshProUGUI levelText = null;
    [SerializeField]
    Slider expSlider = null;

    PlayerLevel playerLevel = null;

    public void Start()
    {
        playerLevel = BackpackUI.instance.player.GetComponent<PlayerLevel>();
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
