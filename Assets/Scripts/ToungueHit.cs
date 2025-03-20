using UnityEngine;

public class TongueHit : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            scoreManager.AddScore(10);
            Destroy(other.gameObject);
        }
    }
}