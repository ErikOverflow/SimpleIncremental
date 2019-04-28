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
    Animator anim = null;

    private void OnDisable()
    {
        chasing = false;
    }

    private void OnDestroy()
    {
        targeting.OnNewTargetAcquired -= StartChasing;
        targeting.OnTargetLost -= StopChasing;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        targeting = GetComponent<EnemyTargeting>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        targeting.OnNewTargetAcquired += StartChasing;
        targeting.OnTargetLost += StopChasing;
    }

    public void StartChasing()
    {
        if (!chasing)
        {
            StartCoroutine(ChaseTarget());
        }
    }

    public void StopChasing()
    {
        chasing = false;
    }

    private IEnumerator ChaseTarget()
    {
        rb2d.drag = 0;
        chasing = true;
        float direction = Mathf.Sign((targeting.target.position - transform.position).x);
        float lastDir = direction;
        yield return new WaitForSeconds(responseTime);
        anim.SetBool("Walking", true);
        anim.SetBool("FacingRight", direction > 0);
        while (chasing)
        {
            direction = Mathf.Sign((targeting.target.position - transform.position).x);
            if (direction != lastDir)
            {
                anim.SetBool("FacingRight", direction > 0);
                lastDir = direction;
            }
            Vector2 vel = rb2d.velocity;
            vel.x = direction * moveSpeed;
            rb2d.velocity = vel;
            yield return new WaitForSeconds(responseTime);
        }
        rb2d.drag = 1;
        anim.SetBool("Walking", false);
    }
}