using System;
using UnityEditor;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
   public GameObject firstPersonCamera;
   public GameObject birdViewCamera;

   private FirstPersonCamera _FirstPersonCameraScript;
   private BirdViewCamera _BirdViewCameraScript;

   private void Awake()
   {
      _FirstPersonCameraScript = GetComponent<FirstPersonCamera>();
      _BirdViewCameraScript = GetComponent<BirdViewCamera>();
      _BirdViewCameraScript.Disable();
      _BirdViewCameraScript.enabled = false;
   }

   private void OnChangeCamera()
   {
      _FirstPersonCameraScript.enabled = !_FirstPersonCameraScript.enabled;
      _BirdViewCameraScript.enabled = !_BirdViewCameraScript.enabled;
   }
}
