using UnityEngine;
using UnityEngine.Audio;

public class AudioChanceVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string floatParam = "MyExposedParam";

    public void ChangeValue(float f)
    {
        audioMixer.SetFloat(floatParam, f);
    }
}