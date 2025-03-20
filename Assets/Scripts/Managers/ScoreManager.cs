using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            IncreaseScore();
        }
    }

    void IncreaseScore()
    {
        score += 10;

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString("0000");
    }

    public void AddScore(int amount)
    {
        score += amount;
        
        UpdateScoreText();
    }
    
}