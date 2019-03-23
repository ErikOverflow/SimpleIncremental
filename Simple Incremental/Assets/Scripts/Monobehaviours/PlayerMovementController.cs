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
    Rigidbody2D rigidBody;
    Vector2 currentVelocity = Vector2.zero;
    float normalizeSpeed = 10f;  //Used to make velocity numbers look reasonable

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontalForce = Input.GetAxis(horizontalAxis);

        var targetVelocity = new Vector2(horizontalForce * horizontalSpeed * normalizeSpeed * Time.deltaTime, rigidBody.velocity.y);
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref currentVelocity, horizontalSmoothing);

        // If the player should jump...
        if (Input.GetKeyDown("space") && IsGrounded())
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }

    }
    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}