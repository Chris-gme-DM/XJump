using UnityEngine;

public class PlayerControls : MonoBehaviour
{
     public float moveSpeed = 5f;
     public RigidBody2D rb;

    private float moveX;

    void Awake()
    {
        rb getcomponent<Rigidbody2D>();
    }


    void Update()
    {
        moveX = Input.GetAxis("Horizontal") + moveSpeed;
    }

    private void fixedupdate()
    {
        vector2 veloctity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
}