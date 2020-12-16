using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement = null;
    [SerializeField] private Animator playerAnimator = null;

    private void OnEnable()
    {
        playerMovement.movementStateChanged += SetMoving;
    }

    private void OnDisable()
    {
        playerMovement.movementStateChanged -= SetMoving;
    }

    private void SetMoving(bool state)
    {
        playerAnimator.SetBool("isWalking", state);
    }
}