using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeCamera : MonoBehaviour
{
   [SerializeField] private FirstPersonCamera firstPersonCameraScript = null;
   [SerializeField] private BirdViewCamera birdViewCameraScript = null;
   [SerializeField] private PlayerMovement playerMovement = null;
   [SerializeField] private PlayerInput playerInput;

   private void Awake()
   {
      birdViewCameraScript.Disable();
      birdViewCameraScript.enabled = false;
   }

   private void OnChangeCamera()
   {
      firstPersonCameraScript.enabled = !firstPersonCameraScript.enabled;
      birdViewCameraScript.enabled = !birdViewCameraScript.enabled;
      playerMovement.enabled = !playerMovement.enabled;
      playerInput.SwitchCurrentActionMap(playerMovement.enabled == true ? "PlayerControl" : "BirdView");
      if (playerMovement.enabled == false)
         Cursor.lockState = CursorLockMode.Confined;
      else
         Cursor.lockState = CursorLockMode.Locked;
   }
}
