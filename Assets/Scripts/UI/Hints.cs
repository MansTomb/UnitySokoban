using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hints : MonoBehaviour
{
    
    [SerializeField] private GameObject hint = null;

    private void Awake()
    {
        string text = InputControlPath.ToHumanReadableString(
            PlayerPrefs.GetString("Interact"),
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        
        hint.GetComponent<TMP_Text>().SetText($"Press {text} to interact");
    }

    public void ButtonWasRebinded(string actionRebinded, string actionButton)
    {
        if (actionRebinded == "Interact")
            hint.GetComponent<TMP_Text>().SetText($"Press {actionButton} to interact");
    }
    
    public void DeleteInteracHint()
    {
        Destroy(hint);
    }
}
