using UnityEngine;

public class BoxParticle : MonoBehaviour
{
    [SerializeField] private BoxMovement boxMovement = null;
    [SerializeField] private ParticleSystem particleSys = null;
    
    private void OnEnable()
    {
        boxMovement.movementStateChanged += ChangeState;
        particleSys.Stop();
    }

    private void OnDisable()
    {
        boxMovement.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            particleSys.Play();
        else
            particleSys.Stop();
    }
}
