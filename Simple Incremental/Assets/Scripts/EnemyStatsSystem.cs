using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemyHook))]
public class EnemyStatsSystem : MonoBehaviour
{
    EnemyHook enemyHook = null;
    List<StatAugment> statAugments;

    public void Awake()
    {
        enemyHook = GetComponent<EnemyHook>();
        statAugments = GetComponentsInChildren<StatAugment>().OrderBy(sa => sa.priority).ToList();
    }

    public void Start()
    {
        ApplyAugments();
    }

    public void ApplyAugments()
    {
        if (enemyHook.Hook())
        {
            foreach (StatAugment augment in statAugments)
            {
                if (augment.Applied)
                    augment.Augment(); //Applies augments in the order of priority.
            }
        }
    }
}
