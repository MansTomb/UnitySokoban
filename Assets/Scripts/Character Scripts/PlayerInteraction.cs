using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public UnityEvent interactedBox;
    public Camera firstPersonCamera;
    
    void OnInteract()
    {
        RaycastHit interactionInfo;
        var camTransform = firstPersonCamera.transform;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out interactionInfo, 2f, 1 << 6, QueryTriggerInteraction.Ignore))
        {
            GameObject obj = interactionInfo.collider.gameObject;
            obj.GetComponent<Interactable>().Interact(gameObject);
            
            if (obj.CompareTag("Box"))
                interactedBox?.Invoke();
        }
    }
}
