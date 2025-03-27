using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer UI text
    public TextMeshProUGUI towerText; // Towers UI text
    public TextMeshProUGUI healthText; // Health UI text

    public float buildPhaseDuration = 60f; // Build phase duration (seconds)
    private float timeRemaining; // Remaining time for the current phase
    private bool isWavePhase = false; // Flag to check if it's wave phase
    private bool isBuildPhase = true; // Flag to check if it's build phase
    public GameManager gameManager; // Reference to GameManager

    void Start()
    {
        timeRemaining = buildPhaseDuration; // Initialize the time remaining for the build phase
        UpdateUI();
    }

    void Update()
    {
        if (isBuildPhase)
        {
            // Update Build Phase Timer
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();

                if (timeRemaining <= 0)
                {
                    timeRemaining = 0;
                    gameManager.StartWavePhase(); // Start the wave phase when the timer reaches 0
                    SwitchToWavePhase();
                }
            }
        }
        else if (isWavePhase)
        {
            // Update Wave Phase Timer (if it's wave phase)
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();

                if (timeRemaining <= 0)
                {
                    timeRemaining = 0;
                    gameManager.EndWavePhase(); // End the wave phase when the timer reaches 0
                }
            }
        }

        // Update Health and Towers UI
        UpdateUI();
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = "Time: " + seconds.ToString();
    }

    void UpdateUI()
    {
        towerText.text = "Towers: " + gameManager.GetCurrentTowers() + "/" + gameManager.maxTowers;
        healthText.text = "Health: " + gameManager.playerHealth;
    }

    // Switch to wave phase and update the UI accordingly
    public void SwitchToWavePhase()
    {
        isBuildPhase = false; // Change phase
        isWavePhase = true; // It's now wave phase
        timeRemaining = gameManager.wavePhaseDuration; // Set wave timer duration
    }

    // Switch to build phase (could be called at the end of the wave phase)
    public void SwitchToBuildPhase()
    {
        isWavePhase = false;
        isBuildPhase = true;
        timeRemaining = buildPhaseDuration; // Set build phase duration
    }
    
    public void UpdateTimerDisplay(float timeRemaining)
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = "Time: " + seconds.ToString();
    }

}
