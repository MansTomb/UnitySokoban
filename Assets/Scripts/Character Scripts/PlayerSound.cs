using System;
using System.Collections;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerMovement playerMovement;

    private Coroutine _Footsteps;
    private WaitWhile _FootstepsCondition;
    private WaitForSeconds _FootstepsInterval;

    private void Awake()
    {
        _FootstepsCondition = new WaitWhile(() => !playerMovement.isMoving);
        _FootstepsInterval = new WaitForSeconds(0.75f);
    }

    private void OnEnable()
    {
        _Footsteps = StartCoroutine(PlayFootstepsSound());
    }

    private void OnDisable()
    {
        StopCoroutine(_Footsteps);
    }

    IEnumerator PlayFootstepsSound()
    {
        while (true)
        {
            yield return _FootstepsCondition;
            audioSource.Play();
            yield return _FootstepsInterval;
        }
    }
}
