using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSoundEffectsSystem : MonoBehaviour
{
    [SerializeField] private BoxMovementSystem _BoxMovementSystem;
    [SerializeField] private AudioSource _AudioSource;
    
    private void OnEnable()
    {
        _BoxMovementSystem.movementStateChanged += ChangeState;
    }

    private void OnDisable()
    {
        _BoxMovementSystem.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            _AudioSource.Play();
    }
}
