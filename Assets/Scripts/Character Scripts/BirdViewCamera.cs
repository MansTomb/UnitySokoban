using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdViewCamera : MonoBehaviour
{
    [SerializeField] private Camera birdCamera = null;
    
    private float _Sensivity = 1;
    private Vector2 _Direction = Vector2.zero;

    private void Awake()
    {
        _Sensivity = PlayerPrefs.GetFloat("Bird View Sensivity", 0.04f);
    }

    void Update()
    {
        CameraControl();
        birdCamera.transform.position += new Vector3(_Direction.x, 0, _Direction.y);
    }
    
    public void SetSensivity(float value)
    {
        _Sensivity = value;
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

    private void OnBirdCamera(InputValue value)
    {
        _Direction = value.Get<Vector2>() * (_Sensivity * 100) * Time.deltaTime;
        Debug.Log($"{value.Get<Vector2>()}");
    }
    
    private void CameraControl()
    {
        Vector3 newPos = birdCamera.transform.position;
        if (Mouse.current.position.y.ReadValue() >= Screen.height - 10f)
        {
            newPos.z += _Sensivity;
        }
        if (Mouse.current.position.y.ReadValue() <= 10f)
        {
            newPos.z -= _Sensivity;
        }
        if (Mouse.current.position.x.ReadValue() >= Screen.width - 10f)
        {
            newPos.x += _Sensivity;
        }
        if (Mouse.current.position.x.ReadValue() <= 10f)
        {
            newPos.x -= _Sensivity;
        }
        birdCamera.transform.position = newPos;
    }
}
