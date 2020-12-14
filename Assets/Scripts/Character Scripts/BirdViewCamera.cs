using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdViewCamera : MonoBehaviour
{
    [SerializeField] private Camera birdCamera;
    [SerializeField] private float sensivity = PlayerPrefs.GetFloat("Bird View Sensivity", 1);

    void Update()
    {
        CameraControl();
    }

    public void Disable()
    {
        birdCamera.enabled = false;
    }

    private void OnEnable()
    {
        var startPos = transform.position;
        startPos.y += 15f;
        birdCamera.transform.position = startPos;
        birdCamera.enabled = true;
    }

    private void OnDisable()
    {
        birdCamera.enabled = false;
    }

    private void CameraControl()
    {
        Vector3 newPos = birdCamera.transform.position;
        if (Mouse.current.position.y.ReadValue() >= Screen.height - 10f)
        {
            newPos.z += sensivity;
        }
        if (Mouse.current.position.y.ReadValue() <= 10f)
        {
            newPos.z -= sensivity;
        }
        if (Mouse.current.position.x.ReadValue() >= Screen.width - 10f)
        {
            newPos.x += sensivity;
        }
        if (Mouse.current.position.x.ReadValue() <= 10f)
        {
            newPos.x -= sensivity;
        }
        birdCamera.transform.position = newPos;
    }
}
