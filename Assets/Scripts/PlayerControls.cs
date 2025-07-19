using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; // Reference to the Rigidbody2D component
    [SerializeField] private float moveSpeed = 5f; // Horizontal movement speed
    [SerializeField] private float jumpForce = 10f; // Force applied when jumping off a platform
    [SerializeField] private float fallThreshold = -10f; // Y position below which the player dies
    [SerializeField] private float screenWrapOffset = 0.5f; // Tweak based on sprite width

    private float horizontalInput;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        // Optional: Wrap player around the screen
        ScreenWrap();

        // Check if player falls below threshold
        if (transform.position.y < fallThreshold)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            if (collision.collider.CompareTag("Platform"))
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void Die()
    {
        // Restart game or trigger game over logic
        Debug.Log("Player Died");
        // For example:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ScreenWrap()
    {
        Vector3 newPosition = transform.position;
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;

        if (transform.position.x > screenHalfWidth + screenWrapOffset)
        {
            newPosition.x = -screenHalfWidth - screenWrapOffset;
        }
        else if (transform.position.x < -screenHalfWidth - screenWrapOffset)
        {
            newPosition.x = screenHalfWidth + screenWrapOffset;
        }

        transform.position = newPosition;
    }
}
