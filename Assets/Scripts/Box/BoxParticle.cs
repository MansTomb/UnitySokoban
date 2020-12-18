using UnityEngine;
using UnityEngine.VFX;

public class BoxParticle : MonoBehaviour
{
    [SerializeField] private BoxMovement boxMovement = null;
    [SerializeField] private VisualEffect particleSys = null;
    
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
