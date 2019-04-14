using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerHook))]
public class PlayerStatsSystem : MonoBehaviour
{
    PlayerHook playerHook = null;
    PlayerWeaponHook playerWeaponHook = null;
    PlayerLevel playerLevel = null;
    List<StatAugment> statAugments;

    [SerializeField]
    GameEvent statsChanged = null;

    public void Awake()
    {
        playerHook = GetComponent<PlayerHook>();
        playerWeaponHook = GetComponentInChildren<PlayerWeaponHook>();
        statAugments = GetComponentsInChildren<StatAugment>().OrderBy(sa => sa.priority).ToList();
        playerLevel = GetComponent<PlayerLevel>();
    }

    public void Start()
    {
        ApplyAugments();
        playerLevel.OnLevelUp += ApplyAugments;
        PlayerInventory.instance.OnItemEquipped += ApplyAugments;
    }

    public void ApplyAugments()
    {
        playerHook.Hook();
        playerWeaponHook.Hook();
        foreach (StatAugment augment in statAugments)
        {
            if (augment.applied)
                augment.Augment();
        }
        statsChanged.Raise();
    }
}