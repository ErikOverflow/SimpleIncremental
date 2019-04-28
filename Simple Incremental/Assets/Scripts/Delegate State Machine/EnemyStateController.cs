using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    //Current State (Default state (idle), Attack, Patrol State, Running State)
    //Actions (Each state has actions that it does).
    //(Transitions) - Decisions

    public EnemyMovementController enemyMovementController = null;
    public EnemyAttackMelee enemyAttackMelee = null;
    public EnemyAttackRanged enemyAttackRanged = null;
    public CharacterLoot characterLoot = null;



}

[CreateAssetMenu(menuName ="Finite State Machine/State")]
public class EnemyState : ScriptableObject
{
    //Actions (Each state has actions that it does).
    //(Transitions) - Decisions
}

public abstract class Action<T> : ScriptableObject
{
    public abstract void Act(T controller);
}

public abstract class Decision<T> : ScriptableObject
{
    public abstract bool Decide(T controller);
}