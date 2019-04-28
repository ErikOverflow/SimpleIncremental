using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErikOverflow.FiniteStateMachine;

[CreateAssetMenu(menuName = "Finite State Machine/Enemy/Decisions/Scan For Target")]
public class ScanForTarget : EnemyDecision
{
    public override bool Decide(EnemyStateData data)
    {
        Collider2D[] colliders = new Collider2D[1];
        if (data.scanningCollider.OverlapCollider(data.cf2d, colliders) > 0)
        {
            data.currentTarget = colliders[0].transform;
            return true;
        }
        return false;
    }
}
