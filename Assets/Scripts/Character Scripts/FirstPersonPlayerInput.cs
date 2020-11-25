using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonPlayerInput : MonoBehaviour
{
    public float movementSpeed = 3;
    public Camera firstPersonCamera;

    private Vector3 _MovementInput;
    private CharacterController _Controller;

    public UnityEvent interactedBox;

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

    void OnInteract()
    {
        RaycastHit interactionInfo;
        var camTransform = firstPersonCamera.transform;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out interactionInfo, 2f, 1 << 6, QueryTriggerInteraction.Ignore))
        {
            GameObject obj = interactionInfo.collider.gameObject;
            obj.GetComponent<Interactable>().Interact(gameObject);
            if (obj.CompareTag("Box"))
                interactedBox?.Invoke();
        }
    }
}