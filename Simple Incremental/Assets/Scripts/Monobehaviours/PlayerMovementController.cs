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
    [SerializeField] float horizontalSpeed = 3f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .5f)] [SerializeField] private float horizontalSmoothing = .05f;

    public LayerMask groundLayer;

    float horizontalForce;
    Rigidbody2D rigidBody;
    Vector2 currentVelocity = Vector2.zero;
    Animator anim;
    int groundedHash = Animator.StringToHash("Grounded");
    CharacterHealth ch = null;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ch = GetComponent<CharacterHealth>();
    }

    private void Start()
    {
        ch.OnDeath += disableInput;
    }

    private void Update()
    {
        horizontalForce = Input.GetAxisRaw(horizontalAxis);

        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool(groundedHash))
        {
            anim.SetTrigger("Jump");
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
    }
    private void FixedUpdate()
    {
        var targetVelocity = new Vector2(horizontalForce * horizontalSpeed, rigidBody.velocity.y);
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, horizontalSmoothing);

        anim.SetFloat("VelocityX", Math.Abs(targetVelocity.x));

        // Flip sprite based on movement direction
        if(horizontalForce < 0 && transform.localScale.x < 0 || horizontalForce > 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (groundLayer == (groundLayer | ( 1<< col.gameObject.layer)))
        {
            anim.SetBool(groundedHash, true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (groundLayer == (groundLayer | (1 << col.gameObject.layer)))
        {
            anim.SetBool(groundedHash, false);
        }
    }
    public void disableInput()
    {
        this.enabled = false;
    }
}