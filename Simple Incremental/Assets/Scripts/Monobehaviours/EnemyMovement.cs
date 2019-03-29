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

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        targeting = GetComponent<EnemyTargeting>();
    }

    private void Start()
    {
        targeting.OnNewTargetAcquired += StartChasing;
        targeting.OnTargetLost += StopChasing;
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
            yield return new WaitForFixedUpdate();
            lastDir = direction;
        }
    }
}