using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class JumpPad : MonoBehaviour
{
    public void Reset(float distance, float offset, float minX, float maxX)
    {
        //Debug.Log("JumpPad Reset Called");
        float newX = transform.position.x + Random.Range(-offset, offset);
        newX = Mathf.Clamp(newX, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y + distance, transform.position.z); 

    }

    public float jumpForce = 10f; // Force applied when the player jumps on the pad
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)

        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
              Vector2 velocity = rb.linearVelocity;
                velocity.y = jumpForce; // Set the vertical velocity to the jump force
                rb.linearVelocity = velocity; 
            }
        }
    }
}
