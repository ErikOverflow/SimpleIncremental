using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErikOverflow.FiniteStateMachine;

[CreateAssetMenu(menuName = "Finite State Machine/Enemy/State")]
public class EnemyState : State<EnemyStateData>
{
    public EnemyAction[] actions;
    public EnemyTransition[] transitions;
    public override Action<EnemyStateData>[] GetActions()
    {
        return actions;
    }

    public override Transition<EnemyStateData>[] GetTransitions()
    {
        return transitions;
    }
}
