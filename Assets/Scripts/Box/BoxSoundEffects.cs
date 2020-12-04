using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSoundEffects : MonoBehaviour
{
    [SerializeField] private BoxMovement boxMovement;
    [SerializeField] private AudioSource _AudioSource;
    
    private void OnEnable()
    {
        boxMovement.movementStateChanged += ChangeState;
    }

    private void OnDisable()
    {
        boxMovement.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            _AudioSource.Play();
    }
}
