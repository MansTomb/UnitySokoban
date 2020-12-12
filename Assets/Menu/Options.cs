using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider master;
    [SerializeField] private Slider music;
    [SerializeField] private Slider effects;

    private void Awake()
    {
        var MasterVolume = PlayerPrefs.GetFloat("Master Volume", master.maxValue);
        var MusicVolume = PlayerPrefs.GetFloat("Music Volume", music.maxValue);
        var EffectsVolume = PlayerPrefs.GetFloat("Effects Volume", effects.maxValue);
        
        mixer.SetFloat("Master", MasterVolume);
        mixer.SetFloat("Music", MusicVolume);
        mixer.SetFloat("Effects", EffectsVolume);
        
        master.SetValueWithoutNotify(MasterVolume);
        music.SetValueWithoutNotify(MusicVolume);
        effects.SetValueWithoutNotify(EffectsVolume);
    }

    public void OnMasterChanged()
    {
        mixer.SetFloat("Master", master.value);
        PlayerPrefs.SetFloat("Master Volume", master.value);
        PlayerPrefs.Save();
    }
    
    public void OnMusicChanged()
    {
        mixer.SetFloat("Music", music.value);
        PlayerPrefs.SetFloat("Music Volume", music.value);
        PlayerPrefs.Save();
    }
    
    public void OnEffectsChanged()
    {
        mixer.SetFloat("Effects", effects.value);   
        PlayerPrefs.SetFloat("Effects Volume", effects.value);
        PlayerPrefs.Save();
    }
}
