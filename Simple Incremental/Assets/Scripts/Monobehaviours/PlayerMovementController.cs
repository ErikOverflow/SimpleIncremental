using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] float horizontalSpeed = 40f;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .5f)] [SerializeField] private float horizontalSmoothing = .05f;
    public LayerMask groundLayer;

    float horizontalForce;
    bool jump;
    Rigidbody2D rigidBody;
    Vector2 currentVelocity = Vector2.zero;
    float normalizeSpeed = 10f;  //Used to make velocity numbers look reasonable
    bool grounded;
    int groundLayerID;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groundLayerID = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        horizontalForce = Input.GetAxisRaw(horizontalAxis);
        if (Input.GetKeyDown("space") && grounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        var targetVelocity = new Vector2(horizontalForce * horizontalSpeed * normalizeSpeed * Time.deltaTime, rigidBody.velocity.y);
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, horizontalSmoothing);

        // If the player should jump...
        if (jump && grounded)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == groundLayerID)
        {
            grounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == groundLayerID)
        {
            grounded = false;
        }
    }
}