using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.VFX;

public class BoxParticle : MonoBehaviour
{
    [SerializeField] private BoxMovement boxMovement = null;

    [SerializeField] private VisualEffect movementVisualEffect = null;
    [SerializeField] private VisualEffect onFinishVisualEffect = null;

    public void OnFinishEnter() => onFinishVisualEffect.Play();
    public void OnFinishExit() => onFinishVisualEffect.Stop();
    
    private void Awake()
    {
        movementVisualEffect.Stop();
        onFinishVisualEffect.Stop();
    }

    private void OnEnable()
    {
        boxMovement.movementStateChanged += ChangeState;
        movementVisualEffect.Stop();
        onFinishVisualEffect.Stop();
    }

    private void OnDisable()
    {
        boxMovement.movementStateChanged -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        if (state)
            movementVisualEffect.Play();
        else
            movementVisualEffect.Stop();
    }
}
