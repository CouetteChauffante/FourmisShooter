using UnityEngine;
using TMPro;

public class PlayerDead : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public GameObject targetObject;

    void Update()
    {
        if (textMeshPro != null && targetObject != null)
        {
            if (textMeshPro.text == "0")
            {
                targetObject.SetActive(true);
            }
            else
            {
                targetObject.SetActive(false);
            }
        }
    }
}
