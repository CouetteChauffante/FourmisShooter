using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public Button quitButton; // Assignez le bouton depuis l'inspecteur

    void Start()
    {
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(Quit);
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Arrête le mode jeu dans l'éditeur
#else
        Application.Quit(); // Ferme l'application dans le build
#endif
    }
}
