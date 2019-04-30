using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Enemy/Actions/Dance")]
public class EnemyDance : EnemyAction
{
    public override void Act(EnemyStateData data)
    {
        data.anim.SetBool("Walking", false);
    }
}
