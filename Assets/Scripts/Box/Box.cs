using UnityEngine;
using UnityEngine.Events;

public class Box : MonoBehaviour
{    
    public Color color;

    public UnityEvent boxZoneEntered;
    public UnityEvent boxZoneExit;
    
    [SerializeField] private Renderer _renderer = null;
    [SerializeField] private Outline outline = null;

    void Start()
    {
        _renderer.material.color = color;
        outline.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            outline.enabled = true;
            boxZoneEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            outline.enabled = false;
            boxZoneExit?.Invoke();
        }
    }
}
