using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float responseTime = 1f;

    Rigidbody2D rb2d = null;
    bool chasing = false;
    Animator anim = null;

    private void OnDisable()
    {
        chasing = false;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void StartChasing(Transform target)
    {
        if (!chasing)
        {
            StartCoroutine(ChaseTarget(target));
        }
    }

    public void StopChasing()
    {
        chasing = false;
    }

    private IEnumerator ChaseTarget(Transform target)
    {
        rb2d.drag = 0;
        chasing = true;
        float direction = Mathf.Sign((target.position - transform.position).x);
        float lastDir = direction;
        yield return new WaitForSeconds(responseTime);
        anim.SetBool("Walking", true);
        anim.SetBool("FacingRight", direction > 0);
        while (chasing)
        {
            direction = Mathf.Sign((target.position - transform.position).x);
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