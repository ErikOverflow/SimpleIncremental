using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    Transform itemsParent;
    InventorySlot[] slots;
    PlayerInventory inventory = null;
    // Start is called before the first frame update
    void Start()
    {
        inventory = PlayerInventory.instance;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.weapons.Count)
            {
                slots[i].CreateSlot(inventory.weapons[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
