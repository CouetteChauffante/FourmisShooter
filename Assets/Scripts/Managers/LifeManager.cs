using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    private int life = 90;
    private int maxLife = 99;

    void Start()
    {
        UpdateLifeText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            RemoveLife(10);
        }
    }

    public void RemoveLife(int amount)
    {
        life -= amount;
        if (life < 0) life = 0;
        UpdateLifeText();
    }

    void UpdateLifeText()
    {
        string displayedLife = (life > maxLife) ? "+99" : life.ToString("00");
        lifeText.text = "Vie: " + displayedLife;

        Debug.Log("Vie = " + life);

        if (life == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}