using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    private Node[,] grid;

    public GameObject gridCellPrefab;  
    public Color evenColor = Color.white;
    public Color oddColor = Color.black;
    public Color spawnColor = Color.red;
    public Color targetColor = Color.green;

    private GameObject[,] gridCells;  // Store references to the grid cells

    public Vector2Int spawnPoint { get; private set; }
    public Vector2Int targetPoint { get; private set; }

    public bool[,] blockedCells;  // Track where towers are placed
    private Dictionary<Vector2Int, int> towerStackHeights; // Dictionary to track stack heights
    public int maxTowerStackHeight = 5; // Maximum stack height

    private void Start()
    {
        gridCells = new GameObject[width, height];
        blockedCells = new bool[width, height];  // Initialize blocked cells
        towerStackHeights = new Dictionary<Vector2Int, int>(); // Initialize stack heights dictionary
        GenerateGrid();
        PlaceSpawnAndTarget();
    }

    // Block a cell when a tower is placed
    public void BlockCell(int x, int y) 
    {
        blockedCells[x, y] = true;  // Mark cell as blocked
    }

    // Unblock a cell if needed (e.g., for tower removal)
    public void UnblockCell(int x, int y) 
    {
        blockedCells[x, y] = false;  // Remove blockage
    }

    // Get stack height for a specific grid position
    public int GetStackHeight(Vector2Int gridPosition)
    {
        if (towerStackHeights.ContainsKey(gridPosition))
        {
            return towerStackHeights[gridPosition];
        }
        return 0; // No towers at this position
    }

    // Increment stack height for a specific grid position
    public void IncrementStackHeight(Vector2Int gridPosition)
    {
        if (towerStackHeights.ContainsKey(gridPosition))
        {
            towerStackHeights[gridPosition]++;
        }
        else
        {
            towerStackHeights[gridPosition] = 1; // First tower placed
        }
    }

    private void GenerateGrid()
    {
        grid = new Node[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldPosition = new Vector3(x * cellSize, 0, y * cellSize);
                grid[x, y] = new Node(x, y, worldPosition);

                // Instantiate grid cell and store reference
                GameObject cell = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                cell.transform.parent = transform;
                gridCells[x, y] = cell;

                // Set default color
                Renderer cellRenderer = cell.GetComponent<Renderer>();
                cellRenderer.material.color = (x + y) % 2 == 0 ? evenColor : oddColor;
            }
        }
    }

    private void PlaceSpawnAndTarget()
    {
        spawnPoint = new Vector2Int(Random.Range(0, width), Random.Range(0, height));

        do
        {
            targetPoint = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (targetPoint == spawnPoint);

        // Change color of the existing grid cell instead of adding new objects
        gridCells[spawnPoint.x, spawnPoint.y].GetComponent<Renderer>().material.color = spawnColor;
        gridCells[targetPoint.x, targetPoint.y].GetComponent<Renderer>().material.color = targetColor;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * cellSize, 0, y * cellSize);
    }

    private class Node
    {
        public int x, y;
        public Vector3 worldPosition;

        public Node(int x, int y, Vector3 worldPosition)
        {
            this.x = x;
            this.y = y;
            this.worldPosition = worldPosition;
        }
    }
}
