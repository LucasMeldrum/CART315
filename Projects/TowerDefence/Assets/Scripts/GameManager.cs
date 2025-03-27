using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GridManager gridManager;
    public GameObject critterPrefab;
    public static GameManager Instance; // Singleton pattern

    public int playerHealth = 10;
    public int maxTowers = 25;
    private int currentTowers = 0;
    public GameObject Resource;  
    private List<GameObject> activeResources = new List<GameObject>();
    //private float resourcePhaseTime = 30f;
    private bool isResourcePhaseActive = false;
    private bool isBuildPhase = true;
    
    public float buildPhaseDuration = 60f; // 60 seconds for building
    public int enemiesToSpawn = 5;
    
    public float wavePhaseDuration = 30f; // Duration for the wave phase
    private float waveTimeRemaining;

    private List<GameObject> activeEnemies = new List<GameObject>(); // To keep track of active enemies

    public void StartResourcePhase()
    {
        Debug.Log("Resource Phase Starting)");
        isResourcePhaseActive = true;
        StartCoroutine(SpawnResources());
        //Invoke(nameof(EndResourcePhase), resourcePhaseTime);
    }

    private IEnumerator SpawnResources()
    {
        if (gridManager == null)
        {
            Debug.LogError("GridManager is not assigned to GameManager! Please assign it in the Inspector.");
            yield break; // Stop the coroutine safely
        }

        while (isResourcePhaseActive)
        {
            Vector2Int randomPos;
            do
            {
                Debug.Log("Resource Spawned");
                randomPos = new Vector2Int(Random.Range(0, gridManager.width), Random.Range(0, gridManager.height));
            } while (gridManager.blockedCells[randomPos.x, randomPos.y]); // Ensure it's not blocked

            Vector3 worldPos = gridManager.GetWorldPosition(randomPos.x, randomPos.y) + Vector3.up * 0.5f;
            GameObject resource = Instantiate(Resource, worldPos, Quaternion.identity);
            activeResources.Add(resource);

            yield return new WaitForSeconds(1f); // Adjust spawn rate
        }
    }


    private void EndResourcePhase()
    {
        isResourcePhaseActive = false;
        foreach (GameObject resource in activeResources)
        {
            if (resource != null) Destroy(resource);
        }
        activeResources.Clear();
    }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start() {
        StartTheGame();
    }
    void StartTheGame()
    {
        waveTimeRemaining = wavePhaseDuration;
        StartBuildPhase();  // Starting the game by default
    }

    public void StartBuildPhase()
    {
        isBuildPhase = true;
        Debug.Log("Build Phase Started!");
        StartCoroutine(StartResourcePhaseWithDelay(0.1f)); // 01 second delay for the grid to load
    }

    private IEnumerator StartResourcePhaseWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartResourcePhase();
    }

    public void StartWavePhase()
{
    isBuildPhase = false;
    EndResourcePhase();
    Debug.Log("Build phase over. Wave starting!");
    StartCoroutine(WavePhaseTimer());
    StartCoroutine(SpawnEnemiesWithDelay());
}
    private IEnumerator WavePhaseTimer()
    {
        while (waveTimeRemaining > 0)
        {
            waveTimeRemaining -= Time.deltaTime;
            yield return null;
        }

        waveTimeRemaining = 0;
        EndWavePhase(); // When the timer finishes, call EndWavePhase to destroy enemies
    }
    public void EndWavePhase()
    {
        Debug.Log("Wave phase ended! All enemies are dying.");
        
        // Destroy all active enemies
        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        activeEnemies.Clear();
    }
private IEnumerator SpawnEnemiesWithDelay()
{
    for (int i = 0; i < enemiesToSpawn; i++)
    {
        SpawnEnemy();
        yield return new WaitForSeconds(1f); // 1-second delay between spawns
    }
}

private void Update() {
    if (Input.GetKeyDown(KeyCode.L))
    {
        Instance.StartResourcePhase();
    }
}

/*
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           StartTheGame();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnEnemy();
        }
    
    }
*/
    private void SpawnEnemy()
    {
        GameObject critterObj = Instantiate(critterPrefab);
        critterObj.GetComponent<Enemy>().Initialize(gridManager);
        activeEnemies.Add(critterObj);
    }
    public void LoseHealth() {
        Debug.Log("You lost 1 Health");
        playerHealth--;

        if (playerHealth <= 0)
        {
            GameOver();
        }
    }

    public bool CanPlaceTower()
    {
        if (isBuildPhase) {
            return currentTowers < maxTowers;
        }

        return false;
    }

    public void AddTower()
    {
        if (CanPlaceTower())
        {
            currentTowers++;
        }
    }
    public int GetCurrentTowers()
    {
        return currentTowers;
    }


    void UpdateUI()
    {
    }

    void GameOver()
    {
        Debug.Log("You Lose");
    }

    public void RestartGame()
    {
       
    }
}

