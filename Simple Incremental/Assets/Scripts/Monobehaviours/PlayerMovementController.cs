using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] float horizontalSpeed = 40f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .5f)] [SerializeField] private float horizontalSmoothing = .05f;

    public LayerMask groundLayer;

    float horizontalForce;
    Rigidbody2D rigidBody;
    Vector2 currentVelocity = Vector2.zero;
    float normalizeSpeed = 10f;  //Used to make velocity numbers look reasonable
    int groundLayerID;
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int groundedHash = Animator.StringToHash("Grounded");

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundLayerID = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        horizontalForce = Input.GetAxisRaw(horizontalAxis);

        if (Input.GetKeyDown("space") && anim.GetBool(groundedHash))
        {
            anim.SetBool(jumpHash, true);
        }
    }

    private void FixedUpdate()
    {
        var targetVelocity = new Vector2(horizontalForce * horizontalSpeed * normalizeSpeed * Time.deltaTime, rigidBody.velocity.y);
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, horizontalSmoothing);

        anim.SetFloat("Speed", Math.Abs(targetVelocity.x));
        anim.SetFloat("VelocityX", horizontalForce);

        // If the player should jump...
        if (anim.GetBool(jumpHash) && anim.GetBool(groundedHash))
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetBool(jumpHash, false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == groundLayerID)
        {
            anim.SetBool(groundedHash, true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == groundLayerID)
        {
            anim.SetBool(groundedHash, false);
        }
    }
}