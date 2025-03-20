using UnityEngine;

public class TongueHit : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Finds the ScoreManager in the scene
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Assuming all ants have the "Ant" tag
        {
            scoreManager.AddScore(10); // Call the existing score function
            Destroy(other.gameObject); // Destroy the ant
        }
    }
}