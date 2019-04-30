using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovementController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float responseTime = 1f;

    Rigidbody2D rb2d = null;
    Animator anim = null;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    public float ChaseTarget(Transform target)
    {
        Vector2 vel = rb2d.velocity;
        float direction = Mathf.Sign((target.position - transform.position).x);
        vel.x = direction * moveSpeed;
        rb2d.velocity = vel;
        return direction;
    }
}