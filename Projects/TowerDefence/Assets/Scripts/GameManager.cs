using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [Header("UI Elements")] public TextMeshProUGUI timerText;
    public TextMeshProUGUI towerText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI waveText;

    [Header("Game Settings")] public GridManager gridManager;
    public GameObject critterPrefab;
    public GameObject resourcePrefab;
    public int playerHealth = 10;
    public int maxTowers = 25;
    public int availableTowers = 25;
    private int waveNumber = 1;

    [Header("Phases Settings")] public float initialBuildPhaseDuration = 60f;
    public float initialWavePhaseDuration = 15f;
    private float buildPhaseDuration;
    private float wavePhaseDuration;
    private float timeRemaining;
    private bool isBuildPhase = true;
    private bool isResourcePhaseActive = false;

    private List<GameObject> activeResources = new List<GameObject>();
    private List<GameObject> activeEnemies = new List<GameObject>();
    public int enemiesToSpawn = 5;
    private int currentTowers = 0;

    void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start() {
        buildPhaseDuration = initialBuildPhaseDuration;
        wavePhaseDuration = initialWavePhaseDuration;
        StartBuildPhase();
        UpdateUI();
    }

    void Update() {
        if (isBuildPhase) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else if (timeRemaining <= 0) {
                timeRemaining = 0;
                StartWavePhase();
            }
        }
    }


    void UpdateUI() {
        towerText.text = "Towers: " + availableTowers;
        healthText.text = "Health: " + playerHealth;
        waveText.text = "Wave: " + waveNumber;
    }

    void UpdateTimerDisplay() {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = "Time: " + seconds.ToString();
    }

    public void StartBuildPhase() {
        isBuildPhase = true;
        isResourcePhaseActive = false; // Reset resource phase status
        CleanupResources(); // Clear old resources
        timeRemaining = buildPhaseDuration;
        Debug.Log("Build Phase Started!");
        StartCoroutine(StartResourcePhaseWithDelay(0.1f));
        UpdateUI();
    }

    private IEnumerator StartResourcePhaseWithDelay(float delay) {
        yield return new WaitForSeconds(delay);
        StartResourcePhase();
    }

    public void StartResourcePhase() {
        if (isResourcePhaseActive) return;
        Debug.Log("Resource Phase Starting!");
        isResourcePhaseActive = true;
        StartCoroutine(SpawnResources());
    }

    private IEnumerator SpawnResources() {
        while (isResourcePhaseActive) {
            Vector2Int randomPos;
            do {
                randomPos = new Vector2Int(Random.Range(0, gridManager.width), Random.Range(0, gridManager.height));
            } while (gridManager.blockedCells[randomPos.x, randomPos.y]);

            Vector3 worldPos = gridManager.GetWorldPosition(randomPos.x, randomPos.y) + Vector3.up * 0.5f;
            GameObject resource = Instantiate(resourcePrefab, worldPos, Quaternion.identity);
            activeResources.Add(resource);
            yield return new WaitForSeconds(1f);
        }
    }

    public void StartWavePhase() {
        isBuildPhase = false;
        timeRemaining = wavePhaseDuration;
        Debug.Log("Wave Phase Started!");
        StopAllCoroutines();
        StartCoroutine(WavePhaseTimer());
        StartCoroutine(SpawnEnemiesWithDelay());
        UpdateUI();
    }

    private IEnumerator WavePhaseTimer() {
        while (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
            yield return null;
        }

        EndWavePhase();
    }

    private IEnumerator SpawnEnemiesWithDelay() {
        for (int i = 0; i < enemiesToSpawn; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnEnemy() {
        GameObject critterObj = Instantiate(critterPrefab);
        critterObj.GetComponent<Enemy>().Initialize(gridManager);
        activeEnemies.Add(critterObj);
    }

    public void EndWavePhase() {
        Debug.Log("Wave Phase Ended! Cleaning up...");
        waveNumber++;
        PlayerPrefs.SetInt("FinalWave", waveNumber);
        foreach (GameObject enemy in activeEnemies) {
            if (enemy != null) {
                Destroy(enemy);
            }
        }

        activeEnemies.Clear();

        buildPhaseDuration = Mathf.Max(10f, buildPhaseDuration - 5f);
        wavePhaseDuration += 5f;
        enemiesToSpawn++;
        //CollapseTowers();
        StartBuildPhase();
    }

    private void CleanupResources() {
        foreach (GameObject resource in activeResources) {
            if (resource != null) {
                Destroy(resource);
            }
        }

        activeResources.Clear();
    }

    public void LoseHealth() {
        playerHealth--;
        if (playerHealth <= 0) {
            GameOver();
        }

        UpdateUI();
    }

    void GameOver()
    {
        Debug.Log("Game Over! You Lose.");
    
        // Save the final wave number to PlayerPrefs
        PlayerPrefs.SetInt("FinalWave", waveNumber);
    
        // Load the GameOver scene
        SceneManager.LoadScene("GameOver");
    }



    public bool CanPlaceTower() {
        return isBuildPhase && availableTowers > 0;
    }

    public void AddTower() {
        if (CanPlaceTower()) {
            availableTowers--;
        }
    }

    public float GetTimeRemaining() {
        return timeRemaining;
    }

    public int GetWaveNumber() {
        return waveNumber;
    }

    /*public void CollapseTowers() {
        Dictionary<Vector2Int, List<Tower>> towersByGridPos = new Dictionary<Vector2Int, List<Tower>>();

        foreach (Tower tower in FindObjectsOfType<Tower>()) {
            Vector2Int gridPos = new Vector2Int(
                Mathf.RoundToInt(tower.transform.position.x),
                Mathf.RoundToInt(tower.transform.position.z)
            );

            if (!towersByGridPos.ContainsKey(gridPos)) {
                towersByGridPos[gridPos] = new List<Tower>();
            }

            towersByGridPos[gridPos].Add(tower);
        }

        foreach (var entry in towersByGridPos) {
            Vector2Int gridPos = entry.Key;
            List<Tower> towers = entry.Value;

            if (towers.Count > 0) {
                // Sort towers from lowest to highest
                towers.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));

                // Destroy all but the lowest tower
                for (int i = 1; i < towers.Count; i++) {
                    Destroy(towers[i].gameObject);
                }

                // Ensure the lowest tower drops to ground level
                Tower lowestTower = towers[0];
                lowestTower.transform.position = new Vector3(gridPos.x, 0, gridPos.y);

                // Update stack height
                gridManager.SetStackHeight(gridPos, 1);
            }
        }

        // Ensure `blockedCells` correctly reflects the collapsed state
        gridManager.RecalculateBlockedCells();

        // Force all enemies to recalculate paths
        foreach (Enemy enemy in FindObjectsOfType<Enemy>()) {
            enemy.RecalculatePath();
        }
    } */
}