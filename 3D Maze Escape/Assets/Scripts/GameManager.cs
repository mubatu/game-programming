using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // A static boolean to remember our state
    private static bool isRestarting = false;

    public GameObject startPanel;
    public GameObject infoPanel;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null) { instance = this; }

        // Check if the scene just reloaded because of the Try Again button
        if (isRestarting)
        {
            // We are restarting,bypass the menu and start the game immediately.
            Time.timeScale = 1f; 
            startPanel.SetActive(false);
            infoPanel.SetActive(false);
            winPanel.SetActive(false);
            gameOverPanel.SetActive(false);

            // Reset the flag so the main menu shows up next time you boot the game cold
            isRestarting = false; 
        }
        else
        {
            // Normal boot up: Freeze the game and show the Start Panel
            Time.timeScale = 0f; 
            startPanel.SetActive(true);
            infoPanel.SetActive(false);
            winPanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }
    }

    // --- BUTTON FUNCTIONS ---

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void ShowInfo()
    {
        infoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
    }

    public void RestartGame()
    {
        // Tell the static variable that we are restarting BEFORE we reload the scene
        isRestarting = true;
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // --- GAME STATE FUNCTIONS ---

    public void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; 
    }
}