using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu; // Assignez ici le GameObject du menu de pause dans l'inspecteur
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
