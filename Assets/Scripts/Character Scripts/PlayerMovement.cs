using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public delegate void MovementStateChanged(bool state);

    public event MovementStateChanged movementStateChanged;
    
    [SerializeField] private CharacterController controller = null;
    [SerializeField] private float movementSpeed = 3;

    private Vector3 _MovementInput = Vector3.zero;

    private bool _IsMoving = false;
    public bool isMoving => _IsMoving;

    void Update()
    {
        if (_IsMoving == false)
            return;
        
        Vector3 move = transform.right * _MovementInput.x + transform.forward * _MovementInput.y;
        controller.Move(move * (movementSpeed * Time.deltaTime));
    }

    private void OnDisable()
    {
        _IsMoving = false;
        movementStateChanged?.Invoke(_IsMoving);
    }

    private void OnMove(InputValue value)
    {
        if (!isActiveAndEnabled)
            return;

        _MovementInput = value.Get<Vector2>().normalized;
        if (_IsMoving != (_MovementInput != Vector3.zero))
        {
            _IsMoving = _MovementInput != Vector3.zero;
            movementStateChanged?.Invoke(_IsMoving);
        }
    }
}
