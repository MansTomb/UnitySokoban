using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu = null;
    [SerializeField] private PlayerInput playerInput = null;
    [SerializeField] private FirstPersonCamera firstPersonCamera = null;
    [SerializeField] private BirdViewCamera birdViewCamera = null;

    public void BirdCameraSensivityChanged(float value)
    {
        
    }

    public void FpsCameraSensivtyChanged(float value)
    {
        
    }

    private void OnMenu()
    {
        playerInput.SwitchCurrentActionMap("Menu");
        menu.SetActive(true);
    }

    private void OnExitMenu()
    {
        playerInput.SwitchCurrentActionMap("PlayerControl");
        menu.SetActive(false);
    }
}
