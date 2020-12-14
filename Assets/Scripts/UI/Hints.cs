using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hints : MonoBehaviour
{
    
    [SerializeField] private GameObject hint;

    private void Awake()
    {
        string text = InputControlPath.ToHumanReadableString(
            PlayerPrefs.GetString("Interact"),
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        
        hint.GetComponent<TMP_Text>().SetText($"Press {text} to push");
    }

    public void DeletePushHint()
    {
        Destroy(hint);
    }
}
