using System;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

public class Box : MonoBehaviour
{
    public Color color;
    public UnityEvent boxZoneEntered;
    public UnityEvent boxZoneExit;
    
    private Renderer _Renderer;
    private Outline _Outline;
    private Vector3 _Destination;

    private bool _IsMoving = false;
    
    void Start()
    {
        _Renderer = GetComponent<Renderer>();
        _Outline = GetComponent<Outline>();
        _Renderer.material.color = color;
        _Outline.enabled = false;
    }

    private void Update()
    {
        if (_IsMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _Destination, 10f * Time.deltaTime);
            if (transform.position == _Destination)
                _IsMoving = false;
        }
    }

    public void Push(GameObject Player)
    {
        if (_IsMoving)
            return;
        
        Vector3 dir = Vector3.zero;
        float minAngle = 370;
        float angle;
        Transform t = Player.transform;

        if ((angle = Vector3.Angle(t.forward, Vector3.forward)) < minAngle)
        {
            dir = Vector3.forward;
            minAngle = angle;
        }
        if ((angle = Vector3.Angle(t.forward, Vector3.left)) < minAngle)
        {
            dir = Vector3.left;
            minAngle = angle;
        }
        if ((angle = Vector3.Angle(t.forward, Vector3.right)) < minAngle)
        {
            dir = Vector3.right;
            minAngle = angle;
        }
        if (Vector3.Angle(t.forward, Vector3.back) < minAngle)
        {
            dir = Vector3.back;
        }
        _Destination = transform.position + dir;
        RaycastHit ray;
        if (Physics.Raycast(transform.position, dir, out ray, 1f) == false)
        {
            _IsMoving = true;
        }
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
