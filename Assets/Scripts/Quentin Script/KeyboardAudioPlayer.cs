using UnityEngine;

public class KeyboardAudioPlayer : MonoBehaviour
{
    public KeyCode keyToPress = KeyCode.Space; // Touche par défaut
    public AudioClip audioClip; // Piste audio à jouer
    private AudioSource audioSource;

    void Start()
    {
        // Ajouter un AudioSource si non présent
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; // Activer la boucle
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            PlayAudio();
        }
        else if (Input.GetKeyUp(keyToPress))
        {
            StopAudio();
        }
    }

    public void SetKey(KeyCode newKey)
    {
        keyToPress = newKey;
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
            audioSource.Play();
        }
    }

    private void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}