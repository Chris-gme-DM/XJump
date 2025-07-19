using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    float maxY;

    void Start()
    {
        if (player == null) return;
        maxY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player.position.y > maxY)
        {
            maxY = player.position.y;
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }
    }
}