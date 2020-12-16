using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu = null;
    [SerializeField] private PlayerInput playerInput = null;
    
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
