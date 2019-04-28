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

    public void ChaseTarget(Transform target)
    {
        rb2d.drag = 0;
        float direction = Mathf.Sign((target.position - transform.position).x);
        anim.SetBool("Walking", true);
        anim.SetBool("FacingRight", direction > 0);
        Vector2 vel = rb2d.velocity;
        vel.x = direction * moveSpeed;
        rb2d.velocity = vel;
        rb2d.drag = 1;
        anim.SetBool("Walking", false);
    }
}