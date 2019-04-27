using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] float maxSpeed = 3f;
    [SerializeField] float acceleration = 100f;
    [SerializeField] private float jumpForce = 400f;

    public LayerMask groundLayer;

    float horizontalForce;
    Rigidbody2D rigidBody;
    Vector2 currentVelocity = Vector2.zero;
    CharacterHealth ch = null;
    Animator anim = null;
    bool grounded = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        ch = GetComponent<CharacterHealth>();
    }

    private void Update()
    {
        horizontalForce = Input.GetAxis(horizontalAxis);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
        anim.SetBool("Running", horizontalForce != 0);
        if(horizontalForce != 0)
        {
            anim.SetBool("FacingRight", horizontalForce > 0);
        }
    }

    private void Jump()
    {
        rigidBody.AddForce(new Vector2(0f, jumpForce));
        grounded = false;
    }

    private void FixedUpdate()
    {
        if (horizontalForce != 0)
        {
            rigidBody.AddForce(horizontalForce * Vector2.right * acceleration);
        }
        Vector2 vel = rigidBody.velocity;
        if(Mathf.Abs(vel.x) > maxSpeed)
        {
            rigidBody.velocity = new Vector2(maxSpeed * Mathf.Sign(vel.x), vel.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (groundLayer == (groundLayer | ( 1<< col.gameObject.layer)))
        {
            grounded = true;
        }
    }
}
