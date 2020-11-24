using UnityEngine;

public class Box : MonoBehaviour
{
    public Color _Color;
    
    private Renderer _Renderer;
    
    void Start()
    {
        _Renderer = GetComponent<Renderer>();
        _Renderer.material.color = _Color;
    }
}
