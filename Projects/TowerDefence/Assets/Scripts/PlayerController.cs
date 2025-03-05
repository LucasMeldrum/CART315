using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridPosition = new Vector2Int(0, 0);
    public float heightAboveGrid = 1f;  // Height above the grid
    public GameObject towerPrefab;      // Reference to the tower prefab

    private void Start()
    {
        // Set the player's position above the grid
        transform.position = new Vector3(gridManager.GetWorldPosition(gridPosition.x, gridPosition.y).x,
                                          heightAboveGrid, 
                                          gridManager.GetWorldPosition(gridPosition.x, gridPosition.y).z);
    }

    private void Update()
    {
        // Player movement
        if (Input.GetKeyDown(KeyCode.W)) Move(0, 1);
        if (Input.GetKeyDown(KeyCode.S)) Move(0, -1);
        if (Input.GetKeyDown(KeyCode.A)) Move(-1, 0);
        if (Input.GetKeyDown(KeyCode.D)) Move(1, 0);

        // When space bar is pressed, instantiate the tower at the player's position
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceTower();
        }
    }

    private void Move(int x, int y)
    {
        Vector2Int newPos = gridPosition + new Vector2Int(x, y);

        if (newPos.x >= 0 && newPos.x < gridManager.width &&
            newPos.y >= 0 && newPos.y < gridManager.height)
        {
            gridPosition = newPos;
            // Set the player's position above the new grid position
            transform.position = new Vector3(gridManager.GetWorldPosition(gridPosition.x, gridPosition.y).x,
                                              heightAboveGrid, 
                                              gridManager.GetWorldPosition(gridPosition.x, gridPosition.y).z);
        }
    }

    private void PlaceTower()
    {
        // Instantiate the tower at the player's grid position, with the height above the grid
        Vector3 towerPosition = new Vector3(gridManager.GetWorldPosition(gridPosition.x, gridPosition.y).x,
                                            heightAboveGrid,
                                            gridManager.GetWorldPosition(gridPosition.x, gridPosition.y).z);

        // Instantiate the tower prefab at the calculated position
        Instantiate(towerPrefab, towerPosition, Quaternion.identity);
    }
}
