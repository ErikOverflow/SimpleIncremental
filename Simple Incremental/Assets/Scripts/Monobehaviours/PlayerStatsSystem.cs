using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerHook))]
public class PlayerStatsSystem : MonoBehaviour
{
    PlayerHook playerHook = null;
    WeaponHook weaponHook = null;
    CharacterLevel characterLevel = null;
    List<StatAugment> statAugments;

    [SerializeField]
    GameEvent statsChanged = null;

    public void Awake()
    {
        playerHook = GetComponent<PlayerHook>();
        weaponHook = GetComponentInChildren<WeaponHook>();
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
        weaponHook.Hook();
        foreach (StatAugment augment in statAugments)
        {
            if (augment.applied)
                augment.Augment();
        }
        statsChanged.Raise();
    }
}