using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private Slider audioSlider;
    [SerializeField] private AudioSource audioObject;
    private AudioSource mainAudioSource;
    [HideInInspector] readonly public string audioSafe = "audio";
    private void Awake()
    {
        if (PlayerPrefs.GetFloat(audioSafe) == 0)
        {
            PlayerPrefs.SetFloat(audioSafe, 0.3f);
        }
        mainAudioSource = GetComponent<AudioSource>();
        mainAudioSource.volume = PlayerPrefs.GetFloat(audioSafe);
        audioSlider.value = mainAudioSource.volume*10;
        audioSlider.onValueChanged.AddListener(AudioChange);
    }

    private void AudioChange(float arg0)
    {
        mainAudioSource.volume = audioSlider.value/10;
        PlayerPrefs.SetFloat(audioSafe, mainAudioSource.volume);
    }
}