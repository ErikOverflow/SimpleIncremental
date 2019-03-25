using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] float horizontalSpeed = 40f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .5f)] [SerializeField] private float horizontalSmoothing = .05f;

    public LayerMask groundLayer;

    float horizontalForce;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    Vector2 currentVelocity = Vector2.zero;
    float normalizeSpeed = 10f;  //Used to make velocity numbers look reasonable
    int groundLayerID;
    Animator anim;
    int groundedHash = Animator.StringToHash("Grounded");

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundLayerID = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        horizontalForce = Input.GetAxisRaw(horizontalAxis);

        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool(groundedHash))
        {
            anim.SetTrigger("Jump");
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("Attack");
        }

        var targetVelocity = new Vector2(horizontalForce * horizontalSpeed * normalizeSpeed * Time.deltaTime, rigidBody.velocity.y);
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, horizontalSmoothing);

        anim.SetFloat("Speed", Math.Abs(targetVelocity.x));
        anim.SetFloat("VelocityX", horizontalForce);

        // Flip sprite based on movement direction
        if ((horizontalForce > 0 && spriteRenderer.flipX) || 
            (horizontalForce < 0 && !spriteRenderer.flipX))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
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