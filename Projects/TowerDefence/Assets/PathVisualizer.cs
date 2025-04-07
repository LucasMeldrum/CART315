using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class PathVisualizer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GridManager gridManager;

    [Header("Line Settings")]
    public float baseHeight = 1f;  // Default height if no towers
    public float extraHeightAboveTowers = 1f;  // Ensure line is above towers
    public float lineWidth = 0.25f;
    public Color pathColor = new Color(0.5f, 0, 0.5f, 1); // Dark Purple

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = pathColor;
        lineRenderer.endColor = pathColor;
        lineRenderer.positionCount = 0;
    }

    public void Initialize(GridManager grid)
    {
        gridManager = grid;
        UpdatePath();
    }

    public void UpdatePath()
    {
        List<Vector2Int> path = AStarPathfinding.FindPath(gridManager, gridManager.spawnPoint, gridManager.targetPoint);

        if (path == null || path.Count == 0)
        {
            lineRenderer.positionCount = 0; // No valid path
            return;
        }

        lineRenderer.positionCount = path.Count;

        for (int i = 0; i < path.Count; i++)
        {
            Vector2Int gridPos = path[i];

            // Get the current max stack height at this position
            int stackHeight = gridManager.GetStackHeight(gridPos);
            float pathHeight = baseHeight + (stackHeight * 1.2f) + extraHeightAboveTowers;

            Vector3 worldPos = gridManager.GetWorldPosition(gridPos.x, gridPos.y) + Vector3.up * pathHeight;
            lineRenderer.SetPosition(i, worldPos);
        }
    }
}