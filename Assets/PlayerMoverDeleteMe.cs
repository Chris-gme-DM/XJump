using UnityEngine;

public class PlayerMoverDeleteMe : MonoBehaviour
{
    [SerializeField] private float speed; // Speed of the player movement
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, speed, 0); // Move the player to the right
    }
}
