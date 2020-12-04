using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{    
    public Color color;

    public UnityEvent boxZoneEntered;
    public UnityEvent boxZoneExit;
    
    [SerializeField] private Renderer _Renderer;
    [SerializeField] private Outline _Outline;

    void Start()
    {
        _Renderer.material.color = color;
        _Outline.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _Outline.enabled = true;
        boxZoneEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        _Outline.enabled = false;
        boxZoneExit?.Invoke();
    }
}
