using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Enemy/Actions/Chase")]
public class EnemyChase : EnemyAction
{
    public override void Act(EnemyStateData data)
    {
        float direction = data.enemyMovementController.ChaseTarget(data.currentTarget);
        data.anim.SetBool("Walking", true);
        data.anim.SetBool("FacingRight", direction > 0);
    }
}
