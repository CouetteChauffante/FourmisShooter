using UnityEngine;
using TMPro; // For TextMeshPro

public class IncreaseScoreOnKey : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
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
}