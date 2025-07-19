using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);

        HandleScreenWrap();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.y <= 0 && col.collider.CompareTag("Platform"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void HandleScreenWrap()
    {
        float halfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Vector3 pos = transform.position;

        if (pos.x > halfWidth) pos.x = -halfWidth;
        if (pos.x < -halfWidth) pos.x = halfWidth;

        transform.position = pos;
    }
}