using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    void Start()
    {
        // Si ce script est attaché à un bouton UI, on ajoute automatiquement l'événement onClick
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(RestartScene);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
