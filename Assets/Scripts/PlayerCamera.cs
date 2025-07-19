using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to player transform
    private float highestY; // Track highest Y the player has reached

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned to CameraFollow script!");
            return;
        }

        highestY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player.position.y > highestY)
        {
            highestY = player.position.y;

            // Follow player only upwards
            transform.position = new Vector3(transform.position.x, highestY, transform.position.z);
        }
    }
}

