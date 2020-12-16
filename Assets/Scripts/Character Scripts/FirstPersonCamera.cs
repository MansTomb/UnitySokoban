using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Camera playerCamera = null;

    private float _Sensivity = 5;
    private Vector2 _MouseInput = Vector2.zero;
    private float _MouseX;

    private void Start()
    {
        _Sensivity = PlayerPrefs.GetFloat("First Person Sensivity", 5);
    }

    private void Update()
    {
        CameraControl();
    }
    
    public void SetSensivity(float value)
    {
        _Sensivity = value;
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
        _MouseX -= _MouseInput.y;
        _MouseX = Mathf.Clamp(_MouseX, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(_MouseX, 0f, 0f);
        transform.Rotate(Vector3.up * _MouseInput.x);
    }

    private void OnCamera(InputValue value)
    {
        _MouseInput = value.Get<Vector2>() * _Sensivity * Time.deltaTime;
    }
}