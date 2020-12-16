using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSoundEffects : MonoBehaviour
{
    [SerializeField] private BoxMovement boxMovement = null;
    [SerializeField] private AudioSource audioSource = null;
    
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
            audioSource.Play();
    }
}
