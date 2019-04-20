using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] float horizontalSpeed = 3f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .5f)] [SerializeField] private float horizontalSmoothing = .05f;

    public LayerMask groundLayer;

    UnityArmatureComponent armatureComponent;
    float horizontalForce;
    Rigidbody2D rigidBody;
    Vector2 currentVelocity = Vector2.zero;
    bool grounded = true;
    CharacterHealth ch = null;
    string jumpAnimName = "Jump";
    string fallAnimName = "land";
    string runAnimName = "run";
    string idleAnimName = "Idle2";
    bool running = false;
    bool lastStateRunning = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        armatureComponent = GetComponent<UnityArmatureComponent>();
        ch = GetComponent<CharacterHealth>();
    }

    private void Start()
    {
        ch.OnDeath += DisableInput;
    }

    private void Update()
    {
        horizontalForce = Input.GetAxisRaw(horizontalAxis);
        if(horizontalForce != 0)
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //anim.SetTrigger("Jump");
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            armatureComponent.animation.FadeIn(jumpAnimName, -1, 1, 1, "Blend");
            //armatureComponent.animation.PlayConfig(new AnimationConfig { animation = jumpAnimName, additiveBlending = true, layer = 1 });
        }
    }
    private void FixedUpdate()
    {
        var targetVelocity = new Vector2(horizontalForce * horizontalSpeed, rigidBody.velocity.y);
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, horizontalSmoothing);

        if(running && !lastStateRunning)
        {
            lastStateRunning = true;
            armatureComponent.animation.FadeIn(runAnimName, -1, 0, 1, "Blend");
        }
        else if(!running)
        {
            lastStateRunning = false;
            armatureComponent.animation.FadeIn(idleAnimName, -1, 0, 1, "Blend");
        }
            
        if (horizontalForce < 0 && armatureComponent.armature.flipX || horizontalForce > 0 && !armatureComponent.armature.flipX)
        {
            armatureComponent.armature.flipX = !armatureComponent.armature.flipX;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (groundLayer == (groundLayer | (1 << col.gameObject.layer)))
        {
            grounded = true;
            armatureComponent.animation.FadeIn(fallAnimName, -1, 1, 1, "Blend");
            //armatureComponent.animation.PlayConfig(new AnimationConfig { animation = fallAnimName, additiveBlending = true, layer = 1 });
            //anim.SetBool(groundedHash, true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (groundLayer == (groundLayer | (1 << col.gameObject.layer)))
        {
            grounded = false;
        }
    }

    public void DisableInput()
    {
        enabled = false;
    }
}