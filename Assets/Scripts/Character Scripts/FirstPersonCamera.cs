using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    
    [SerializeField] private float sensivity = 10f;

    private Vector2 _MouseInput = Vector2.zero;
    private float _MouseX;

    void Update()
    {
        CameraControl();
    }

    private void OnDisable()
    {
        playerCamera.enabled = false;
    }

    private void OnEnable()
    {
        playerCamera.enabled = true;
    }

    private void CameraControl()
    {
        _MouseX += _MouseInput.y;
        _MouseX = Mathf.Clamp(_MouseX, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(_MouseX, 0f, 0f);
        transform.Rotate(Vector3.up * _MouseInput.x);
    }

    private void OnCamera(InputValue value)
    {
        _MouseInput = value.Get<Vector2>() * sensivity * Time.deltaTime;
    }
}