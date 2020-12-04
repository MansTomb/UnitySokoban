using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundSystem : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerMovementSystem playerMovementSystem;

    private Coroutine _Footsteps;
    private void OnEnable()
    {
        playerMovementSystem.movementStateChanged += PlayFootsteps;
    }

    private void OnDisable()
    {
        playerMovementSystem.movementStateChanged -= PlayFootsteps;
        if (_Footsteps != null)
            StopCoroutine(_Footsteps);
    }

    private void PlayFootsteps(bool state)
    {
        if (state)
        {
            if (_Footsteps != null)
                StopCoroutine(_Footsteps);
            _Footsteps = StartCoroutine(PlayFootstepsSound());
        }
        else
        {
            StopCoroutine(_Footsteps);
        }
    }

    IEnumerator PlayFootstepsSound()
    {
        while (true)
        {
            audioSource.Play();
            yield return new WaitForSeconds(0.75f);
        }
    }
}
