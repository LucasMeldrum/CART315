using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    private GridManager gridManager;
    private Vector2Int currentGridPos;
    private List<Vector2Int> path;
    private int pathIndex;
    public int health = 20;

    public void Initialize(GridManager grid)
    {
        gridManager = grid;
        currentGridPos = grid.spawnPoint;
        transform.position = grid.GetWorldPosition(currentGridPos.x, currentGridPos.y) + Vector3.up; // Spawn above grid

        FindPath();
    }

    private void Update()
    {
        if (path != null && pathIndex < path.Count)
        {
            Vector3 targetPos = gridManager.GetWorldPosition(path[pathIndex].x, path[pathIndex].y) + Vector3.up;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                pathIndex++;
            }
        }
        else if (pathIndex >= path.Count) // Enemy reached goal
        {
            GameManager.Instance.LoseHealth();
            Destroy(gameObject);
        }
    }


    private void FindPath()
    {
        path = AStarPathfinding.FindPath(gridManager, currentGridPos, gridManager.targetPoint);
        pathIndex = 0;
    }
    
    public void RecalculatePath()
    {
        FindPath(); // Call FindPath again to update pathing
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Enemy dies
        }
    }
}