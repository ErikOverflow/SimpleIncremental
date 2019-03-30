using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    Transform itemsParent = null;
    InventorySlot[] slots;
    [SerializeField]
    InventorySlot weaponSlot = null;
    bool initialized = false;
    // Start is called before the first frame update
    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        initialized = true;
        UpdateUI();
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        if(initialized)
            UpdateUI();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void UpdateUI()
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
