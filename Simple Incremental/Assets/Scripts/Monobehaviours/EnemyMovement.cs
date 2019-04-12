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
        targeting.OnNewTargetAcquired += StartChasing;
        targeting.OnTargetLost += StopChasing;
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
        float direction = Mathf.Sign((targeting.target.position - transform.position).x);
        float lastDir = direction;
        chasing = true;
        while (chasing)
        {
            Vector2 lastVel = rb2d.velocity;
            direction = Mathf.Sign((targeting.target.position - transform.position).x);
            if (lastDir != direction)
            {
                yield return new WaitForSeconds(responseTime);
            }
            rb2d.velocity = new Vector2(direction * moveSpeed, lastVel.y);
            anim.SetFloat(speedHash, Math.Abs(rb2d.velocity.x));
            yield return new WaitForFixedUpdate();
            lastDir = direction;

            // Flip character based on movement direction
            if (direction < 0 && transform.localScale.x > 0 || direction > 0 && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

        }
    }
}