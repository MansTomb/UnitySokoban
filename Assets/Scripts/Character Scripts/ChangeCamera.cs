using System;
using UnityEditor;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
   public GameObject firstPersonCamera;
   public GameObject birdViewCamera;

   [SerializeField] private FirstPersonCamera firstPersonCameraScript;
   [SerializeField] private BirdViewCamera birdViewCameraScript;
   [SerializeField] private PlayerMovementSystem playerMovementSystem;

   private void Awake()
   {
      birdViewCameraScript.Disable();
      birdViewCameraScript.enabled = false;
   }

   private void OnChangeCamera()
   {
      firstPersonCameraScript.enabled = !firstPersonCameraScript.enabled;
      birdViewCameraScript.enabled = !birdViewCameraScript.enabled;
      playerMovementSystem.enabled = !playerMovementSystem.enabled;
   }
}
