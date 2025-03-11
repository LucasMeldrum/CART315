using System.Collections.Generic;
using UnityEngine;

public static class AStarPathfinding
{
    public static List<Vector2Int> FindPath(GridManager grid, Vector2Int start, Vector2Int goal)
    {
        HashSet<Vector2Int> closedSet = new HashSet<Vector2Int>();
        PriorityQueue<Vector2Int> openSet = new PriorityQueue<Vector2Int>();
        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        Dictionary<Vector2Int, float> gScore = new Dictionary<Vector2Int, float> { [start] = 0 };
        Dictionary<Vector2Int, float> fScore = new Dictionary<Vector2Int, float> { [start] = Heuristic(start, goal) };

        openSet.Enqueue(start, fScore[start]);

        while (openSet.Count > 0)
        {
            Vector2Int current = openSet.Dequeue();

            if (current == goal)
                return ReconstructPath(cameFrom, current);

            closedSet.Add(current);

            foreach (Vector2Int neighbor in GetNeighbors(grid, current))
            {
                if (closedSet.Contains(neighbor) || grid.blockedCells[neighbor.x, neighbor.y])
                    continue;

                float tentativeGScore = gScore[current] + 1;

                if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor, goal);

                    if (!openSet.Contains(neighbor))
                        openSet.Enqueue(neighbor, fScore[neighbor]);
                }
            }
        }
        return null;
    }

    private static List<Vector2Int> GetNeighbors(GridManager grid, Vector2Int pos)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        foreach (var dir in directions)
        {
            Vector2Int neighbor = pos + dir;
            if (neighbor.x >= 0 && neighbor.x < grid.width && neighbor.y >= 0 && neighbor.y < grid.height)
            {
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    private static float Heuristic(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y); // Manhattan distance
    }

    private static List<Vector2Int> ReconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current)
    {
        List<Vector2Int> path = new List<Vector2Int> { current };
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Insert(0, current);
        }
        return path;
    }
}
