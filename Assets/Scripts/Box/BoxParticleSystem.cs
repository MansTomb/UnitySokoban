using UnityEngine;

public class BoxParticleSystem : MonoBehaviour
{
    [SerializeField] private BoxMovementSystem _BoxMovementSystem;
    [SerializeField] private ParticleSystem _ParticleSystem;
    
    private void OnEnable()
    {
        _BoxMovementSystem.movementStateChanged += ChangeState;
        _ParticleSystem.Stop();
    }

    private void OnDisable()
    {
        _BoxMovementSystem.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            _ParticleSystem.Play();
        else
            _ParticleSystem.Stop();
    }
}
