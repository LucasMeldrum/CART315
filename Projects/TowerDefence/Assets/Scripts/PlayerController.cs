using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridManager gridManager;
    public Vector2Int gridPosition = new Vector2Int(0, 0);
    public float heightAboveGrid = 1f;  
    public GameObject towerPrefab;      

    private void Start()
    {
        UpdatePlayerPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Move(0, 1);
        if (Input.GetKeyDown(KeyCode.S)) Move(0, -1);
        if (Input.GetKeyDown(KeyCode.A)) Move(-1, 0);
        if (Input.GetKeyDown(KeyCode.D)) Move(1, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceTower();
        }
    }

    private void Move(int x, int y)
    {
        Vector2Int newPos = gridPosition + new Vector2Int(x, y);

        if (IsWithinGrid(newPos))
        {
            gridPosition = newPos;
            UpdatePlayerPosition();
        }
    }

    private void UpdatePlayerPosition()
    {
        Vector3 worldPos = gridManager.GetWorldPosition(gridPosition.x, gridPosition.y);
        transform.position = new Vector3(worldPos.x, heightAboveGrid, worldPos.z);
    }

    private void PlaceTower()
    {
        Vector3 towerPosition = gridManager.GetWorldPosition(gridPosition.x, gridPosition.y);
        Debug.Log("Tower Position: " + towerPosition);
    
        // Get current stack height for the grid position
        int stackHeight = gridManager.GetStackHeight(gridPosition);

        // Check if the stack height exceeds the maximum limit
        if (stackHeight >= gridManager.maxTowerStackHeight)
        {
            Debug.Log("Max tower stack reached at position: " + gridPosition);
            return; // Don't place more towers
        }

        // Calculate new tower position by stacking upwards
        Vector3 stackedPosition = towerPosition + Vector3.up * (heightAboveGrid + (stackHeight * 1.2f)); 

        Debug.Log("Stacked Position: " + stackedPosition);

        // If no stacking, just place normally
        if (GameManager.Instance.CanPlaceTower()) 
        {
            GameObject newTower = Instantiate(towerPrefab, stackedPosition, Quaternion.identity);
            newTower.tag = "Tower";
        
            // Increase the range of the tower as it stacks
            Tower towerScript = newTower.GetComponent<Tower>();
            towerScript.range += stackHeight; // Increase range by 1 for each stack height

            gridManager.BlockCell(gridPosition.x, gridPosition.y);
            gridManager.IncrementStackHeight(gridPosition); // Increment the stack height
            GameManager.Instance.AddTower();
            Debug.Log("Tower Placed at: " + stackedPosition + " with range: " + towerScript.range);
        }
        else
        {
            Debug.Log("No more towers allowed!");
        }
    }

    private bool IsWithinGrid(Vector2Int position)
    {
        return position.x >= 0 && position.x < gridManager.width &&
               position.y >= 0 && position.y < gridManager.height;
    }
}