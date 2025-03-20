using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public TextMeshProUGUI lifeText; // Reference to the TextMeshProUGUI component
    private int life = 90;

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
    }

    public void RemoveLife(int amount)
    {
        life -= amount;
        
        UpdateLifeText();
    }
}
