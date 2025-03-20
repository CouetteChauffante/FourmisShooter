using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    public KeyCode restartKey = KeyCode.R; // Touche de redémarrage
    public float holdTime = 2f; // Temps en secondes avant le redémarrage

    private float keyHoldDuration = 0f;
    private bool isHolding = false;

    void Update()
    {
        if (Input.GetKey(restartKey))
        {
            if (!isHolding)
            {
                isHolding = true;
                keyHoldDuration = 0f;
            }

            keyHoldDuration += Time.deltaTime;

            if (keyHoldDuration >= holdTime)
            {
                RestartGame();
            }
        }
        else if (Input.GetKeyUp(restartKey))
        {
            isHolding = false;
            keyHoldDuration = 0f;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
