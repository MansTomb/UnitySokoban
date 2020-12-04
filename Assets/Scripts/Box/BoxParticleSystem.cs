using UnityEngine;

public class BoxParticleSystem : MonoBehaviour
{
    [SerializeField] private Box _Box;
    [SerializeField] private ParticleSystem _ParticleSystem;
    
    private void OnEnable()
    {
        _Box.movementStateChanged += ChangeState;
        _ParticleSystem.Stop();
    }

    private void OnDisable()
    {
        _Box.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            _ParticleSystem.Play();
        else
            _ParticleSystem.Stop();
    }
}
