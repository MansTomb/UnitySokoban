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
    private Rigidbody _Rigidbody;
    private ParticleSystem _ParticleSystem;
    private AudioSource _AudioSource;
    
    private Vector3 _MoveDirection = Vector3.zero;
    private Vector3 _Destination;

    private bool _IsMoving = false;
    [SerializeField] private float _MovementSpeed = 0.1f;
    
    void Start()
    {
        _Renderer = GetComponent<Renderer>();
        _Outline = GetComponent<Outline>();
        _Rigidbody = GetComponent<Rigidbody>();
        _ParticleSystem = GetComponent<ParticleSystem>();
        _AudioSource = GetComponent<AudioSource>();
        _Renderer.material.color = color;
        _Outline.enabled = false;
        _ParticleSystem.Stop();
    }

    private void LateUpdate()
    {
        if (_IsMoving)
        {
            _Rigidbody.MovePosition(transform.position + _MoveDirection * Time.fixedDeltaTime);
            if (transform.position == _Destination)
            {
                _IsMoving = false;
                _ParticleSystem.Stop();
            }
        }
    }

    public void Push(GameObject player)
    {
        if (_IsMoving)
            return;
        CalculateMovementDirection(player);
        RaycastHit ray;
        if (Physics.Raycast(transform.position, _MoveDirection, out ray, 1f, 1 << 0,QueryTriggerInteraction.Ignore) == false)
        {
            _ParticleSystem.Play();
            transform.forward = -_MoveDirection;
            _AudioSource.Play();
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
    
    private void CalculateMovementDirection(GameObject player)
    {
        float minAngle = 370;
        float angle;
        Transform t = player.transform;

        if ((angle = Vector3.Angle(t.forward, Vector3.forward)) < minAngle)
        {
            _MoveDirection = Vector3.forward;
            minAngle = angle;
        }

        if ((angle = Vector3.Angle(t.forward, Vector3.left)) < minAngle)
        {
            _MoveDirection = Vector3.left;
            minAngle = angle;
        }

        if ((angle = Vector3.Angle(t.forward, Vector3.right)) < minAngle)
        {
            _MoveDirection = Vector3.right;
            minAngle = angle;
        }

        if (Vector3.Angle(t.forward, Vector3.back) < minAngle)
        {
            _MoveDirection = Vector3.back;
        }

        _MoveDirection *= 4;
        _Destination = transform.position + _MoveDirection;
    }
}
