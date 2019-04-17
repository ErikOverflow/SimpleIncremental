using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyTargeting))]
public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float responseTime = 1f;

    Rigidbody2D rb2d = null;
    EnemyTargeting targeting = null;
    bool chasing = false;
    bool patrolling = false;
    Animator anim;
    int speedHash = Animator.StringToHash("Speed");

    private void OnDisable()
    {
        chasing = false;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        targeting = GetComponent<EnemyTargeting>();
    }

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void StartChasing()
    {
        if (!chasing)
            StartCoroutine(ChaseTarget());
    }

    public void StopChasing()
    {
        chasing = false;
        rb2d.velocity = Vector2.zero;
        anim.SetFloat(speedHash, 0);
    }

    private IEnumerator ChaseTarget()
    {
        Transform target = targeting.target;
        if (!target)
            yield break;
        float direction = Mathf.Sign((target.position - transform.position).x);
        float lastDir = direction;
        chasing = true;
        while (chasing)
        {
            Vector2 lastVel = rb2d.velocity;
            target = targeting.target;
            if (!target)
                yield break;
            direction = Mathf.Sign((target.position - transform.position).x);
            if (lastDir != direction)
            {
                yield return new WaitForSeconds(responseTime);
            }
            rb2d.velocity = new Vector2(direction * moveSpeed, lastVel.y);
            anim.SetFloat(speedHash, Math.Abs(rb2d.velocity.x));
            yield return new WaitForFixedUpdate();
            lastDir = direction;
            flipEnemy(direction);
        }
    }

    public void StartPatrolling()
    {
        if (!patrolling)
            StartCoroutine(Patrol());
    }

    public void StopPatrolling()
    {
        patrolling = false;
        rb2d.velocity = Vector2.zero;
        anim.SetFloat(speedHash, 0);
    }

    private IEnumerator Patrol()
    {
        RaycastHit2D hitWall;
        RaycastHit2D hitGround;

        int layerMask = 1 << 12;
        float direction = -1f;
        patrolling = true;
        while (patrolling)
        {
            hitWall = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 1, layerMask);
            hitGround = Physics2D.Raycast(transform.position, new Vector2(direction, -2), 1, layerMask);
            // If it hit a wall or detect no ground turn around
            if (hitWall.collider != null || hitGround.collider == null)
                direction *= -1f;
            Vector2 lastVel = rb2d.velocity;
            rb2d.velocity = new Vector2(direction * moveSpeed, lastVel.y);
            anim.SetFloat(speedHash, Math.Abs(rb2d.velocity.x));
            flipEnemy(direction);
            yield return new WaitForFixedUpdate();
        }  
    }

    private void flipEnemy(float direction)
    {
        // Flip character based on movement direction
        if (direction < 0 && transform.localScale.x > 0 || direction > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}