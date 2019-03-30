using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerHook))]
public class PlayerStatsSystem : MonoBehaviour
{
    PlayerHook playerHook = null;
    WeaponHook weaponHook = null;
    List<StatAugment> statAugments;

    public void Awake()
    {
        playerHook = GetComponent<PlayerHook>();
        weaponHook = GetComponentInChildren<WeaponHook>();
        statAugments = GetComponentsInChildren<StatAugment>().OrderBy(sa => sa.priority).ToList();
    }

    public void Start()
    {
        ApplyAugments();
    }

    public void ApplyAugments()
    {
        playerHook.Hook();
        weaponHook.Hook();
        foreach (StatAugment augment in statAugments)
        {
            if (augment.Applied)
                augment.Augment();
        }
    }
}