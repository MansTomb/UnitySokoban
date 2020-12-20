using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput input = null;
    
    void Awake()
    {
        input.SwitchCurrentActionMap("PlayerControl");
        Cursor.lockState = CursorLockMode.Locked;
    }
}
