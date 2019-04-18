using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerUpgrades : MonoBehaviour
{
    public static PlayerUpgrades instance;

    public Action UpgradesChanged;

    public List<PlayerUpgrade> upgrades = null;
    public PlayerUpgrade[] equippedUpgrades = new PlayerUpgrade[4];

    //TODO Serialize player upgrades earned and populate this with earned upgrades on load.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ApplyUpgrades()
    {
        for (int i = 0; i < equippedUpgrades.Length; i++)
        {
            equippedUpgrades[i]?.Augment(gameObject);
        }
    }

    public void EquipUpgrade(PlayerUpgrade newUpgrade, int slot)
    {
        upgrades.Remove(newUpgrade);
        equippedUpgrades[slot] = newUpgrade;
        UpgradesChanged?.Invoke();
    }

    public void UnEquipUpgrade(int slot)
    {
        upgrades.Add(equippedUpgrades[slot]);
        equippedUpgrades[slot] = null;
        UpgradesChanged?.Invoke();
    }
}