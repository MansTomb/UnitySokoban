using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu = null;
    [SerializeField] private PlayerInput playerInput = null;
    
    private void OnMenu()
    {
        playerInput.SwitchCurrentActionMap("Menu");
        Cursor.lockState = CursorLockMode.Confined;
        menu.SetActive(true);
    }

    private void OnExitMenu()
    {
        playerInput.SwitchCurrentActionMap("PlayerControl");
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
    }
}
