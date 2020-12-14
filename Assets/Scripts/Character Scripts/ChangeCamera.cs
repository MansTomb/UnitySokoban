using System;
using UnityEditor;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
   [SerializeField] private GameObject firstPersonCamera;
   [SerializeField] private GameObject birdViewCamera;
   
   [SerializeField] private FirstPersonCamera firstPersonCameraScript;
   [SerializeField] private BirdViewCamera birdViewCameraScript;
   [SerializeField] private PlayerMovement playerMovement;

   private void Start()
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
