using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] string horizontalAxis = "Horizontal";
    [SerializeField] float horizontalSpeed = 50f;
    [Range(0, .5f)] [SerializeField] private float horizontalSmoothing = .05f;

    float horizontalForce;
    Rigidbody2D rigidBody;
    Vector2 currentVelocity = Vector2.zero;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalForce = Input.GetAxis(horizontalAxis);
    }

    private void FixedUpdate()
    {
        var target = new Vector2(horizontalForce * horizontalSpeed * 10f * Time.deltaTime, rigidBody.velocity.y);

        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, target, ref currentVelocity, horizontalSmoothing);
    }
}