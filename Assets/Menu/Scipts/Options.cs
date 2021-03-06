using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer = null;
    [SerializeField] private Slider master = null;
    [SerializeField] private Slider music = null;
    [SerializeField] private Slider effects = null;
    [SerializeField] private Slider birdCameraSensivity = null;
    [SerializeField] private Slider fpsCameraSensivity = null;

    public UnityEvent<float> fpsCameraSensivityChanged;
    public UnityEvent<float> birdCameraSensivityChanged;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.0000001f);
        var masterVolume = PlayerPrefs.GetFloat("Master Volume", master.value);
        var musicVolume = PlayerPrefs.GetFloat("Music Volume", music.value);
        var effectsVolume = PlayerPrefs.GetFloat("Effects Volume", effects.value);
        var fpsSensivty = PlayerPrefs.GetFloat("First Person Sensivity", fpsCameraSensivity.value);
        var birdSensivity = PlayerPrefs.GetFloat("Bird View Sensivity", birdCameraSensivity.value);
        
        mixer.SetFloat("Master", masterVolume);
        mixer.SetFloat("Music", musicVolume);
        mixer.SetFloat("Effects", effectsVolume);
        
        master.SetValueWithoutNotify(masterVolume);
        music.SetValueWithoutNotify(musicVolume);
        effects.SetValueWithoutNotify(effectsVolume);
        birdCameraSensivity.SetValueWithoutNotify(birdSensivity);
        fpsCameraSensivity.SetValueWithoutNotify(fpsSensivty);
        
        gameObject.SetActive(false);
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
        birdCameraSensivityChanged?.Invoke(birdCameraSensivity.value);
    }

    public void OnFpsCameraSensivity()
    {
        PlayerPrefs.SetFloat("First Person Sensivity", fpsCameraSensivity.value);
        fpsCameraSensivityChanged?.Invoke(fpsCameraSensivity.value);
    }
}
