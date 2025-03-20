using UnityEngine;
using TMPro;

public class TextMeshProAudioPlayer : MonoBehaviour
{
    public TMP_Text textMeshPro;         // Le TextMeshPro à surveiller
    public AudioClip audioClip;         // Piste audio à jouer
    private AudioSource audioSource;    // Source audio
    private string lastText = "";       // Dernier texte pour comparer si il y a eu un changement

    void Start()
    {
        // Ajouter un AudioSource si non présent
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        // Vérifier si le texte a changé
        if (textMeshPro.text != lastText)
        {
            // Si le texte a changé, jouer le son une fois
            PlayAudio();

            // Mettre à jour le dernier texte
            lastText = textMeshPro.text;
        }
    }

    public void SetAudioClip(AudioClip newClip)
    {
        audioClip = newClip;
        audioSource.clip = audioClip;
    }

    private void PlayAudio()
    {
        if (audioClip != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip); // Jouer le son une seule fois
        }
    }
}
