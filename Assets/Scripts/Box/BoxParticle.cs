using UnityEngine;

public class BoxParticle : MonoBehaviour
{
    [SerializeField] private BoxMovement boxMovement;
    [SerializeField] private ParticleSystem _ParticleSystem;
    
    private void OnEnable()
    {
        boxMovement.movementStateChanged += ChangeState;
        _ParticleSystem.Stop();
    }

    private void OnDisable()
    {
        boxMovement.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            _ParticleSystem.Play();
        else
            _ParticleSystem.Stop();
    }
}
