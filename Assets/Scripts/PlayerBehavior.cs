using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Movement speed

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Cache the Rigidbody2D component
    }

    private void Update()
    {
        Move(); // Call Move() each frame to handle player movement
    }

    // Handles player movement based on WASD input
    private void Move()
    {
        float moveX = 0f;
        float moveY = 0f;

        // Get input for movement (WASD keys)
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        // Normalize the movement vector to avoid faster diagonal movement
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Apply the velocity to the Rigidbody2D component
        rb.linearVelocity = movement * speed;
    }
}
