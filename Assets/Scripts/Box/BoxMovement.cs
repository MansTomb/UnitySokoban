using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public delegate void MovementStateChanged(bool state);

    public event MovementStateChanged movementStateChanged;
    
    [SerializeField] private Rigidbody _Rigidbody;
    [SerializeField] private Interactable _Interactable;
    
    private Vector3 _MoveDirection = Vector3.zero;
    private Vector3 _Destination;
    
    private bool _IsMoving = false;

    private void OnEnable()
    {
        _Interactable.OnInteraction += Push;
    }

    private void OnDisable()
    {
        _Interactable.OnInteraction -= Push;
    }

    private void LateUpdate()
    {
        if (_IsMoving)
        {
            _Rigidbody.MovePosition(transform.position + _MoveDirection * Time.fixedDeltaTime);
            if (transform.position == _Destination)
            {
                RoundPosition();
                _IsMoving = false;
                movementStateChanged?.Invoke(_IsMoving);
            }
        }
    }

    private void Push(GameObject player)
    {
        if (_IsMoving)
            return;
        CalculateMovementDirection(player);
        RaycastHit ray;
        if (Physics.Raycast(transform.position, _MoveDirection, out ray, transform.localScale.x, 1 << 0,QueryTriggerInteraction.Ignore) == false)
        {
            transform.forward = -_MoveDirection;
            _IsMoving = true;
            movementStateChanged?.Invoke(_IsMoving);
        }
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

        _MoveDirection *= transform.localScale.x;
        _Destination = transform.position + _MoveDirection;
    }
    
    private void RoundPosition()
    {
        Vector3 tmp = transform.position;
        tmp.x = Mathf.Round(tmp.x);
        tmp.y = Mathf.Round(tmp.y);
        tmp.z = Mathf.Round(tmp.z);
        transform.position = tmp;
    }
}
