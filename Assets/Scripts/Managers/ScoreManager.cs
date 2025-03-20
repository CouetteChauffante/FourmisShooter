using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;
    private int score = 0;
    private int enemySpawnCount = 0;
    private const int maxEnemies = 32;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString("0000");
    }

    public void RegisterSpawn()
    {
        enemySpawnCount++;
        if (enemySpawnCount >= maxEnemies)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}