using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelUI : PanelUI
{
    [SerializeField]
    Transform slotsParent = null;
    //[SerializeField]
    //InventorySlot weaponSlot = null;
    //[SerializeField]
    //TextMeshProUGUI levelText = null;
    //[SerializeField]
    //Slider expSlider = null;

    InventorySlot[] slots;
    PlayerLevel playerLevel = null;

    public override void Awake()
    {
        base.Awake();
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
    }

    public override void Start()
    {
        base.Start();
        playerLevel = BackpackUI.instance.player.GetComponent<PlayerLevel>();
        BackpackUI.instance.activePanel = this; //Make the active panel this one to start
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
        //if (PlayerInventory.instance.weapon != null)
        //    weaponSlot.CreateSlot(PlayerInventory.instance.weapon);
        //else
        //    weaponSlot.ClearSlot();

        //expSlider.maxValue = playerLevel.nextLevelExp;
        //expSlider.value = playerLevel.experience;
        //levelText.text = "Level " + playerLevel.level.ToString();
    }
}
