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
    public PathVisualizer pathVisualizer;

    [Header("Game Settings")] public GridManager gridManager;
    public GameObject critterPrefab;
    public GameObject resourcePrefab;
    public int playerHealth = 10;
    // public int maxTowers = 25;
    public int availableTowers = 25;
    private int waveNumber = 1;
    private bool keepSpawning;
    
    [Header("Phases Settings")] public float initialBuildPhaseDuration = 60f;
    public float initialWavePhaseDuration = 15f;
    private float buildPhaseDuration;
    private float wavePhaseDuration;
    private float timeRemaining;
    private bool isBuildPhase = true;
    private bool isResourcePhaseActive = false;

    private List<GameObject> activeResources = new List<GameObject>();
    private List<GameObject> activeEnemies = new List<GameObject>();
    // public int enemiesToSpawn = 5;
    private int currentTowers = 0;
    
    [Header("Overlay & Audio")]
    public GameObject phaseOverlay; // A UI panel with Text inside
    public TextMeshProUGUI phaseOverlayText;
    public AudioSource waveMusicSource;
    public AudioClip waveMusic;
    public AudioSource buildMusicSource;
    public AudioClip buildMusic;


    void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start() {
        Debug.Log("Game Started! Setting up Build Phase.");
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
    
    private IEnumerator ShowPhaseOverlay(string phaseName, float duration = 2.5f) {
        phaseOverlayText.text = phaseName;
        phaseOverlay.SetActive(true);
        yield return new WaitForSeconds(duration);
        phaseOverlay.SetActive(false);
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
        isResourcePhaseActive = false;
        CleanupResources();
        timeRemaining = Mathf.Max(1f, buildPhaseDuration);

        Debug.Log("Build Phase Started!");
        StartCoroutine(ShowPhaseOverlay("Build Phase"));
        StartCoroutine(DelayedPathUpdate());
        StartCoroutine(StartResourcePhaseWithDelay(0.1f));
        StopWaveMusic(); // stop wave music
        PlayBuildMusic(); // start build music
        UpdateTimerDisplay();
        UpdateUI();
    }


    private IEnumerator DelayedPathUpdate() {
        yield return new WaitForSeconds(0.1f); // Small delay
        if (pathVisualizer != null && gridManager != null) {
            pathVisualizer.Initialize(gridManager);
        }
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
        keepSpawning = true;
        timeRemaining = wavePhaseDuration;

        Debug.Log("Wave Phase Started!");
        StopAllCoroutines();
        StartCoroutine(ShowPhaseOverlay("Wave Phase"));
        StopBuildMusic();
        PlayWaveMusic();
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
        //for (int i = 0; i < enemiesToSpawn; i++) {
            while (keepSpawning) { 
                SpawnEnemy(); 
                yield return new WaitForSeconds(1f); 
            }
        //}
    }

    private void SpawnEnemy() {
        GameObject critterObj = Instantiate(critterPrefab);
        critterObj.GetComponent<Enemy>().Initialize(gridManager);
        activeEnemies.Add(critterObj);
    }

    public void EndWavePhase() {
        Debug.Log("Wave Phase Ended! Cleaning up...");
        keepSpawning = false;
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
        // enemiesToSpawn++;
        // CollapseTowers();
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
    
    private void PlayWaveMusic() {
        if (waveMusicSource != null && waveMusic != null) {
            waveMusicSource.clip = waveMusic;
            waveMusicSource.loop = false;
            waveMusicSource.pitch = 1f;
            waveMusicSource.Play();
            StartCoroutine(FadeAudio(waveMusicSource, 0.5f, 1f));
            StartCoroutine(SpeedUpMusicOverTime(wavePhaseDuration));
        }
    }

    private void StopWaveMusic() {
        if (waveMusicSource != null) {
            StartCoroutine(FadeAudio(waveMusicSource, 0f, 1f));
        }
    }

    
    private void PlayBuildMusic() {
        if (buildMusicSource != null && buildMusic != null) {
            buildMusicSource.clip = buildMusic;
            buildMusicSource.loop = true;
            buildMusicSource.Play();
            StartCoroutine(FadeAudio(buildMusicSource, 0.5f, 1f)); // Adjust volume to taste
        }
    }

    private void StopBuildMusic() {
        if (buildMusicSource != null) {
            StartCoroutine(FadeAudio(buildMusicSource, 0f, 1f));
        }
    }

    private IEnumerator FadeAudio(AudioSource source, float targetVolume, float duration) {
        if (source == null) yield break;
    
        float startVolume = source.volume;
        float time = 0f;

        while (time < duration) {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        source.volume = targetVolume;

        if (targetVolume == 0f) {
            source.Stop();
        }
    }
    
    private IEnumerator SpeedUpMusicOverTime(float duration) {
        float time = 0f;
        float startPitch = 1f;
        float endPitch = 1.5f; // Speed target

        while (time < duration && waveMusicSource != null && waveMusicSource.isPlaying) {
            time += Time.deltaTime;
            waveMusicSource.pitch = Mathf.Lerp(startPitch, endPitch, time / duration);
            yield return null;
        }

        waveMusicSource.pitch = endPitch;
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