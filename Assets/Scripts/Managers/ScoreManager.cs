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

    private LifeManager lifeManager;
    private int addLifeOne = 100;
    private int addLifeTwo = 200;
    private int addLifeThree = 300;

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
        lifeManager = FindObjectOfType<LifeManager>();
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score == addLifeOne)
        {
            lifeManager.AddLife(10);
        }
        if (score == addLifeTwo)
        {
            lifeManager.AddLife(10);
        }
        if (score == addLifeThree)
        {
            lifeManager.AddLife(10);
        }
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