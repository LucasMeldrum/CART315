using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps; // 3 power-up prefabs in the Inspector
    public Transform[] spawnPositions; // spawn positions in the Inspector

    public float spawnInterval = 10f; // Time between spawns

    void Start()
    {
        InvokeRepeating( "SpawnPowerUp", 2f, spawnInterval); // Start spawning power-ups every 10 seconds
    }

    void SpawnPowerUp()
    {
        Debug.Log("Spawned power-up.");
        // Choose a random power-up
        int randomPowerUpIndex = Random.Range(0, powerUps.Length);

        // Choose a random spawn position
        int randomPositionIndex = Random.Range(0, spawnPositions.Length);

        // Spawn the power-up
        Instantiate(powerUps[randomPowerUpIndex], spawnPositions[randomPositionIndex].position, Quaternion.identity);
    }
}