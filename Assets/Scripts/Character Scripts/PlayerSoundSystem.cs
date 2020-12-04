using System.Collections;
using UnityEngine;

public class PlayerSoundSystem : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerMovementSystem playerMovementSystem;

    private Coroutine _Footsteps;
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
            yield return new WaitWhile(() => !playerMovementSystem.isMoving);
            yield return new WaitForSeconds(0.75f);
            audioSource.Play();
        }
    }
}
