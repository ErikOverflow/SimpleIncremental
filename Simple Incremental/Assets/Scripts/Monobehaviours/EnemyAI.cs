using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

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
    StateMachine<States> fsm;

    public enum States
    {
        Init,
        Patrol,
        AttackRanged,
        AttackMelee
    }

    void Awake()
    {
        enemyTargeting = GetComponent<EnemyTargeting>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttackRanged = GetComponent<EnemyAttackRanged>();
        enemyAttackMelee = GetComponent<EnemyAttackMelee>();
        fsm = StateMachine<States>.Initialize(this);   
    }

    private void Start()
    {
        enemyTargeting.OnNewTargetAcquired += TargetAcquired;
        enemyTargeting.OnTargetLost += TargetLost;
        anim = gameObject.GetComponent<Animator>();
        fsm.ChangeState(States.Init);
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

    void Init_Enter()
    {
        fsm.ChangeState(checkDistance());
    }

    //void Patrol_Enter()
    //{
    //    enemyMovement.StartPatrolling();
    //}

    void Patrol_Update()
    {
        fsm.ChangeState(checkDistance());
    }

    //void Patrol_Exit()
    //{
    //    enemyMovement.StopPatrolling();
    //}

    void AttackRanged_Enter()
    {
        updateChasePlayer();
        enemyAttackRanged.StartFiring();
    }

    void AttackRanged_Update()
    {
        fsm.ChangeState(checkDistance());
    }

    void AttackRanged_Exit()
    {
        enemyAttackRanged.StopFiring();
        chasePlayer = false;
        enemyMovement.StopChasing();
    }


    private void AttackMelee_Enter()
    {
        updateChasePlayer();
    }

    private void AttackMelee_Update()
    {
        fsm.ChangeState(checkDistance());
    }

    private void AttackMelee_Exit()
    {
        chasePlayer = false;
        enemyMovement.StopChasing();
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

    private States checkDistance()
    {
        if (targetAcquired)
        {      
            if (playerDistanceX < rangedWeaponDistanceMax && playerDistanceX > rangedWeaponDistanceMin)
            {
                return States.AttackRanged;
            }
            else
            {
                return States.AttackMelee;
            }
        }
        else
        {
            return States.Patrol;
        }

    }

    public void Update()
    {
        updateTargetDistance();      
    }

}
