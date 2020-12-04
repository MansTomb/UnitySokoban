using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSoundEffectsSystem : MonoBehaviour
{
    [SerializeField] private Box _Box;
    [SerializeField] private AudioSource _AudioSource;
    
    private void OnEnable()
    {
        _Box.movementStateChanged += ChangeState;
    }

    private void OnDisable()
    {
        _Box.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            _AudioSource.Play();
    }
}
