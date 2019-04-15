using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    [Header("UI Objects")]
    [SerializeField]
    Transform itemsParent = null;
    InventorySlot[] slots;
    [SerializeField]
    InventorySlot weaponSlot = null;
    [SerializeField]
    Image backpackImage = null;
    [SerializeField]
    Sprite openBackpackSprite = null;
    [SerializeField]
    TextMeshProUGUI levelText = null;
    [SerializeField]
    Slider expSlider = null;


    [Header("PlayerObject")]
    [SerializeField]
    GameObject player = null;

    PlayerLevel playerLevel = null;
    bool initialized = false;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            playerLevel = player.GetComponent<PlayerLevel>();
        }
    }

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        initialized = true;
        UpdateUI();
    }

    private void OnEnable()
    {
        if(initialized)
            UpdateUI();
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

        expSlider.maxValue = playerLevel.nextLevelExp;
        expSlider.value = playerLevel.experience;
        levelText.text = "Level " + playerLevel.level.ToString();
    }

    public void ToggleInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf)
            backpackImage.overrideSprite = openBackpackSprite;
        else
            backpackImage.overrideSprite = null;
    }
}
