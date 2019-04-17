using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTargeting))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttackRanged))]
[RequireComponent(typeof(EnemyAttackMelee))]
public class EnemyAI : MonoBehaviour
{
    EnemyTargeting enemyTargeting;
    EnemyMovement enemyMovement;
    EnemyAttackRanged enemyAttackRanged;
    EnemyAttackMelee enemyAttackMelee;
    Animator anim;
    public int closestRange = 1;
    public int rangedWeaponDistanceMax;
    public int rangedWeaponDistanceMin;
    private float playerDistanceX;

    bool targetAcquired = false;
    bool chasePlayer = false;
    enum AIState { none, patrol, attackRanged, attackMelee}
    AIState previousState = AIState.none;
    AIState nextState = AIState.none;

    void Awake()
    {
        enemyTargeting = GetComponent<EnemyTargeting>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttackRanged = GetComponent<EnemyAttackRanged>();
        enemyAttackMelee = GetComponent<EnemyAttackMelee>();
    }

    private void Start()
    {
        enemyTargeting.OnNewTargetAcquired += TargetAcquired;
        enemyTargeting.OnTargetLost += TargetLost;
        anim = gameObject.GetComponent<Animator>();
    }

    public void TargetAcquired()
    {
        targetAcquired = true;
        updateTargetDistance();
    }

    public void TargetLost()
    {
        targetAcquired = false;
    }

    private void updateTargetDistance()
    {
        if (enemyTargeting && enemyTargeting.target)
        { 
            playerDistanceX = Mathf.Abs(enemyTargeting.target.position.x - transform.position.x);
        }
    }

    private void StateNone()
    {
        //Action

        previousState = nextState;
        //Decision
        checkDistance();

    }
    private void StatePatrol()
    {
        //Action
        if (previousState != nextState)
        { 
            enemyMovement.StartPatrolling();
        }
        previousState = nextState;
        //Decision
        checkDistance();
        if (nextState != AIState.patrol)
        {
            enemyMovement.StopPatrolling();
        }
    }

    private void StateAttackRanged()
    {
        //Action
        if (previousState != nextState)
        {
            updateChasePlayer();
            enemyAttackRanged.StartFiring();
        }

        previousState = nextState;
        //Decision
        checkDistance();
        if (nextState != AIState.attackRanged)
        {
            enemyAttackRanged.StopFiring();

        }
        if (nextState != AIState.attackMelee && nextState != AIState.attackRanged) 
        {
            chasePlayer = false;
            enemyMovement.StopChasing();
        }
    }

    private void StateAttackMelee()
    {
        //Action
        if (previousState != nextState)
            updateChasePlayer();

        enemyAttackMelee.StartAttacking();

        previousState = nextState;
        //Decision
        checkDistance();
        if (nextState != AIState.attackMelee && nextState != AIState.attackRanged)
        {
            chasePlayer = false;
            enemyMovement.StopChasing();
        }
    }

    //Used to determine movement patterns
    private void updateChasePlayer()
    {
        if (chasePlayer == false)
        {
            //Chase Player
            if (playerDistanceX > closestRange)
            {
                chasePlayer = true;
                enemyMovement.StartChasing();
            }
        }
        else
        {
            //Stop Chasing Player when its really close
            if (playerDistanceX < closestRange)
            {
                chasePlayer = false;
                enemyMovement.StopChasing();
            }
        }
    }

    private void checkDistance()
    {
        if (targetAcquired)
        {      
            if (playerDistanceX < rangedWeaponDistanceMax && playerDistanceX > rangedWeaponDistanceMin)
            {
                nextState = AIState.attackRanged;
            }
            else
            {
                nextState = AIState.attackMelee;
            }
        }
        else
        {
            nextState = AIState.patrol;
        }

    }

    public void Update()
    {
        updateTargetDistance();
        
        switch (nextState)
        {
            case (AIState.none):
                StateNone();
                break;
            case (AIState.patrol):
                StatePatrol();
                break;
            case (AIState.attackMelee):
                StateAttackMelee();
                break;
            case (AIState.attackRanged):
                StateAttackRanged();
                break;
        }

    }

}
