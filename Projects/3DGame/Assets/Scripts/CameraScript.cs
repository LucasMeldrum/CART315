using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;  // Assign the player object here
    public Vector3 offset = new Vector3(0, 10, -5); // Adjust for best top-down angle
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.LookAt(target.position);  // Keeps the camera looking at the player
    }
}
