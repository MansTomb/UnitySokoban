using System;
using UnityEditor;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
   [SerializeField] private FirstPersonCamera firstPersonCameraScript = null;
   [SerializeField] private BirdViewCamera birdViewCameraScript = null;
   [SerializeField] private PlayerMovement playerMovement = null;

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
   }
}
