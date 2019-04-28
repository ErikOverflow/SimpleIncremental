using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErikOverflow.FiniteStateMachine;

public class EnemyStateController : StateController<EnemyStateData>
{
    public EnemyState currentState;
    public EnemyState remainInState;

    public override State<EnemyStateData> GetCurrentState()
    {
        return currentState;
    }

    public override State<EnemyStateData> GetRemainState()
    {
        return remainInState;
    }

    public override void SetCurrentState(State<EnemyStateData> state)
    {
        currentState = state as EnemyState;
    }
}
