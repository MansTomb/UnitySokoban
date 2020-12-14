using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider master;
    [SerializeField] private Slider music;
    [SerializeField] private Slider effects;
    [SerializeField] private Slider birdCameraSensivity;
    [SerializeField] private Slider fpsCameraSensivity;

    private void Awake()
    {
        var masterVolume = PlayerPrefs.GetFloat("Master Volume", master.maxValue);
        var musicVolume = PlayerPrefs.GetFloat("Music Volume", music.maxValue);
        var effectsVolume = PlayerPrefs.GetFloat("Effects Volume", effects.maxValue);
        var fpsSensivty = PlayerPrefs.GetFloat("First Person Sensivity", fpsCameraSensivity.maxValue / 2);
        var birdSensivity = PlayerPrefs.GetFloat("Bird View Sensivity", birdCameraSensivity.maxValue / 2);
        
        mixer.SetFloat("Master", masterVolume);
        mixer.SetFloat("Music", musicVolume);
        mixer.SetFloat("Effects", effectsVolume);
        
        master.SetValueWithoutNotify(masterVolume);
        music.SetValueWithoutNotify(musicVolume);
        effects.SetValueWithoutNotify(effectsVolume);
        birdCameraSensivity.SetValueWithoutNotify(birdSensivity);
        fpsCameraSensivity.SetValueWithoutNotify(fpsSensivty);
    }

    public void OnMasterChanged()
    {
        mixer.SetFloat("Master", master.value);
        PlayerPrefs.SetFloat("Master Volume", master.value);
    }
    
    public void OnMusicChanged()
    {
        mixer.SetFloat("Music", music.value);
        PlayerPrefs.SetFloat("Music Volume", music.value);
    }
    
    public void OnEffectsChanged()
    {
        mixer.SetFloat("Effects", effects.value);   
        PlayerPrefs.SetFloat("Effects Volume", effects.value);
    }

    public void OnBirdCameraSensivity()
    {
        PlayerPrefs.SetFloat("Bird View Sensivity", birdCameraSensivity.value);
    }

    public void OnFpsCameraSensivity()
    {
        PlayerPrefs.SetFloat("First Person Sensivity", fpsCameraSensivity.value);
    }
}
