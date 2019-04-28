using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErikOverflow.FiniteStateMachine;

[System.Serializable]
public class EnemyTransition : Transition<EnemyStateData>
{
    public EnemyDecision decision;
    public EnemyState falseState;
    public EnemyState trueState;

    public override Decision<EnemyStateData> GetDecision()
    {
        return decision;
    }

    public override State<EnemyStateData> GetFalseState()
    {
        return falseState;
    }

    public override State<EnemyStateData> GetTrueState()
    {
        return trueState;
    }
}
