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

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject critterObj = Instantiate(critterPrefab);
        critterObj.GetComponent<Enemy>().Initialize(gridManager);
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
        return currentTowers < maxTowers;
    }

    public void AddTower()
    {
        if (CanPlaceTower())
        {
            currentTowers++;
        }
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

