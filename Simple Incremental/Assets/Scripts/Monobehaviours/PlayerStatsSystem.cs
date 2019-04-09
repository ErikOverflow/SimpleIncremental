using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerHook))]
public class PlayerStatsSystem : MonoBehaviour
{
    PlayerHook playerHook = null;
    PlayerWeaponHook playerWeaponHook = null;
    CharacterLevel characterLevel = null;
    List<StatAugment> statAugments;

    public void Awake()
    {
        playerHook = GetComponent<PlayerHook>();
        playerWeaponHook = GetComponentInChildren<PlayerWeaponHook>();
        statAugments = GetComponentsInChildren<StatAugment>().OrderBy(sa => sa.priority).ToList();
        characterLevel = GetComponent<CharacterLevel>();
    }

    public void Start()
    {
        ApplyAugments();
        characterLevel.OnLevelUp += ApplyAugments;
    }

    public void ApplyAugments()
    {
        playerHook.Hook();
        playerWeaponHook.Hook();
        foreach (StatAugment augment in statAugments)
        {
            if (augment.Applied)
                augment.Augment();
        }
    }
}