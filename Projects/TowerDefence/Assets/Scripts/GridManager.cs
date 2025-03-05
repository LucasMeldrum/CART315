using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    private Node[,] grid;

    public GameObject gridCellPrefab;  // Prefab for the grid cells
    public Color evenColor = Color.white;  // Color for even cells
    public Color oddColor = Color.black;  // Color for odd cells

    private void Start()
    {
        GenerateGrid();
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

                // Instantiate a prefab for each cell
                GameObject cell = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                cell.transform.parent = transform;  // Make the grid cells children of this object

                // Apply color based on whether it's an even or odd cell
                Renderer cellRenderer = cell.GetComponent<Renderer>();
                if ((x + y) % 2 == 0)
                {
                    cellRenderer.material.color = evenColor;  // Color for even cells
                }
                else
                {
                    cellRenderer.material.color = oddColor;  // Color for odd cells
                }
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return grid[x, y].worldPosition;
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