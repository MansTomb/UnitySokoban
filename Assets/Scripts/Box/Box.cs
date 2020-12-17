using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{    
    public Color color;

    public UnityEvent boxZoneEntered;
    public UnityEvent boxZoneExit;
    
    [SerializeField] private Renderer _renderer = null;

    void Start()
    {
        _renderer.material.SetColor("_BaseColor", color);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            boxZoneEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            boxZoneExit?.Invoke();
        }
    }
}
