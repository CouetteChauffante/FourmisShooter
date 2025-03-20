using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI lifeText; // Reference to the TextMeshProUGUI component
    private int life = 90;
    private int lifeTotal = 100;

    void Start()
    {
        UpdateLifeText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            DecreaseLife();
        }
    }

    void DecreaseLife()
    {
        life -= 10;

        UpdateLifeText();
    }

    void UpdateLifeText()
    {
        lifeText.text = "Vie: " + life.ToString("00");
        lifeTotal -= 10;
        Debug.Log("Vie = "+lifeTotal);
        if (lifeTotal == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void RemoveLife(int amount)
    {
        life -= amount;
        
        UpdateLifeText();
    }
}
