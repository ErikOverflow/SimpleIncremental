using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(WeaponHook))]
public class WeaponStatsSystem : MonoBehaviour
{
    WeaponHook weaponHook = null;
    List<StatAugment> statAugments;

    public void Awake()
    {
        weaponHook = GetComponent<WeaponHook>();
        statAugments = GetComponentsInChildren<StatAugment>().OrderBy(sa => sa.priority).ToList();
    }

    public void Start()
    {
        ApplyAugments();
    }

    public void ApplyAugments()
    {
        if (weaponHook.Hook())
        {
            foreach (StatAugment augment in statAugments)
            {
                if (augment.Applied)
                    augment.Augment();
            }
        }
    }
}