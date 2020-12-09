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
        float value;
        mixer.GetFloat("Master", out value);
        master.SetValueWithoutNotify(value);
        
        mixer.GetFloat("Music", out value);
        music.SetValueWithoutNotify(value);
        
        mixer.GetFloat("Effects", out value);
        effects.SetValueWithoutNotify(value);
    }

    public void OnMasterChanged()
    {
        mixer.SetFloat("Master", master.value);
    }
    
    public void OnMusicChanged()
    {
        mixer.SetFloat("Music", music.value);
    }
    
    public void OnEffectsChanged()
    {
        mixer.SetFloat("Effects", effects.value);   
    }
}
