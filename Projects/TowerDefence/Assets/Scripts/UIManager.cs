using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI towerText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI waveText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        UpdateUI();
    }

    void Update()
    {
        if (gameManager != null)
        {
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(gameManager.GetTimeRemaining()).ToString();
        towerText.text = "Towers: " + gameManager.availableTowers;
        healthText.text = "Health: " + gameManager.playerHealth;
        waveText.text = "Wave: " + gameManager.GetWaveNumber();
    }
}