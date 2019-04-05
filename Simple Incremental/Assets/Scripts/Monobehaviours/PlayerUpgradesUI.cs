using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradesUI : MonoBehaviour
{
    PlayerUpgrade[] playerUpgrades = null;
    [SerializeField]
    Transform upgradesParent = null;
    [SerializeField]
    GameObject upgradeSlotPrefab = null;
    bool initialized = false;

    private void Awake()
    {
        playerUpgrades = PlayerInventory.instance.GetComponentsInChildren<PlayerUpgrade>();
    }

    private void Start()
    {
        initialized = true;
        UpdateUI();
    }

    private void OnEnable()
    {
        if (initialized)
            UpdateUI();
    }

    void UpdateUI()
    {
        PlayerUpgradeSlot[] slots = GetComponentsInChildren<PlayerUpgradeSlot>();
        foreach(PlayerUpgradeSlot slot in slots)
        {
            slot.gameObject.SetActive(false);
            ObjectPooler.instance.ReleasePooledObject(slot.GetComponent<PoolableObject>());
        }
        for (int i = 0; i < playerUpgrades.Length; i++)
        {
            GameObject go = ObjectPooler.instance.GetPooledObject(upgradeSlotPrefab);
            go.transform.SetParent(upgradesParent);
            go.GetComponent<PlayerUpgradeSlot>().CreateSlot(playerUpgrades[i]);
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
        }
    }
}
