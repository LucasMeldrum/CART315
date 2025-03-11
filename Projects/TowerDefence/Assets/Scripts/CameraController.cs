using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset;    // Offset from the player (can be adjusted in inspector)
    public float rotationSpeed = 50f;  // Speed of camera rotation

    private bool isFollowingPlayer = true; // Flag to track if camera should follow the player

    void Start()
    {
        // Set the initial offset for top-down view (or default view)
        if (player != null)
        {
            offset = new Vector3(0, 10, -10); // Default offset (behind the player)
        }

        // Set the initial position and focus on the player
        transform.position = player.position + offset;
        transform.LookAt(player.position);  // Focus the camera on the player
    }

    void Update()
    {
        // Switch to default view when Q is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetView(0);  // Default view
        }

        // Switch to top-down view when E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetView(1);  // Top-down view
        }

        // Update the camera position to follow the player if needed
        if (isFollowingPlayer)
        {
            transform.position = player.position + offset;
            transform.LookAt(player.position); // Keep the camera focused on the player
        }
    }

    // Switch camera to a specific view
    private void SetView(int viewIndex)
    {
        if (viewIndex == 0) // Default view
        {
            offset = new Vector3(0, 10, -10); // Camera behind the player
        }
        else if (viewIndex == 1) // Top-down view
        {
            offset = new Vector3(0, 10, 0); // Camera directly above the player
        }

        // Update the camera position based on the selected view
        transform.position = player.position + offset;
        transform.LookAt(player.position); // Keep the camera focused on the player
    }
}
