using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalWaveText;

    void Start()
    {
        // Retrieve the final wave number from PlayerPrefs
        int finalWave = PlayerPrefs.GetInt("FinalWave", 1);  // Default to 1 if not found

        // Display the final wave number on the UI
        finalWaveText.text = "Final Wave: " + finalWave;
    }
    public void LoadMainMenu()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    // This function will be called when the player clicks the "Quit" button
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();  // Exits the application
    }
}