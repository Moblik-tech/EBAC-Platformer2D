using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    public AudioSource audioSource;

    public void Play()
    {
        audioSource.Play();
    }
}