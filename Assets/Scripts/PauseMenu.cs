using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
