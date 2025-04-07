using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float heightAboveGrid = 0;  
    public GameObject towerPrefab;  
    public GridManager gridManager;

    private void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceTower();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Resource"))
        {
            GameManager.Instance.availableTowers += 2; // Only increase available towers
            Destroy(other.gameObject);
            Debug.Log("Collected Resource! Available Towers: " + GameManager.Instance.availableTowers);
        }
    }



    // Smooth movement using WASD
    private void HandleMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ = 1f;
        if (Input.GetKey(KeyCode.S)) moveZ = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (moveDirection.magnitude > 0)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    // Place a tower and snap it to the nearest grid cell
    private void PlaceTower()
{
    // Snap to nearest grid using Mathf.Round
    Vector3 snappedPosition = new Vector3(Mathf.Round(transform.position.x), heightAboveGrid, Mathf.Round(transform.position.z)
    );

    Debug.Log($"Snapped Tower Position: {snappedPosition}");

    // Get grid position
    Vector2Int gridPos = new Vector2Int((int)snappedPosition.x, (int)snappedPosition.z);

    // Check if placing a tower would block the enemy path
    if (!gridManager.CanBlockCell(gridPos.x, gridPos.y))
    {
        Debug.Log("Cannot place tower here! It would block all paths.");
        return;
    }

    // Calculate stacking
    int stackHeight = gridManager.GetStackHeight(gridPos);
    if (stackHeight >= gridManager.maxTowerStackHeight)
    {
        Debug.Log("Max tower stack reached at position: " + snappedPosition);
        return;
    }

    // Adjust the Y position for stacking
    snappedPosition.y += stackHeight * 1.2f;

    if (GameManager.Instance.CanPlaceTower())
    {
        GameObject newTower = Instantiate(towerPrefab, snappedPosition, Quaternion.identity);
        newTower.tag = "Tower";

        Tower towerScript = newTower.GetComponent<Tower>();
        towerScript.range += stackHeight;
        towerScript.stackHeight = stackHeight + 1; // Set the correct stack height

        // Adjust color based on stack height
        Renderer renderer = newTower.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            Color baseColor = Color.grey;
            Color maxColor = Color.red;
            float t = Mathf.Clamp01(stackHeight / (float)gridManager.maxTowerStackHeight);
            renderer.material.color = Color.Lerp(baseColor, maxColor, t);
        }

        // Block the cell and update stacking height
        gridManager.BlockCell(gridPos.x, gridPos.y);
        gridManager.IncrementStackHeight(gridPos);

        GameManager.Instance.AddTower();
        Debug.Log($"Tower Placed at: {snappedPosition} with range: {towerScript.range} and stackHeight: {towerScript.stackHeight}");
    }
}

}
