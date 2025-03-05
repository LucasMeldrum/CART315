using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset;    // Offset from the player

    void Start()
    {
        // Set the initial offset
        if (player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Follow the player's position with the offset
            transform.position = player.position + offset;
        }
    }
}