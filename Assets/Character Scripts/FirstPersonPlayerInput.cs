using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonPlayerInput : MonoBehaviour
{
    public float movementSpeed = 3;

    private Vector3 _MovementInput;
    private CharacterController _Controller;

    private void Awake()
    {
        _Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = transform.right * _MovementInput.x + transform.forward * _MovementInput.y;
        _Controller.Move(move * (movementSpeed * Time.deltaTime));
    }

    private void OnMove(InputValue value)
    {
        _MovementInput = value.Get<Vector2>().normalized;
    }
}