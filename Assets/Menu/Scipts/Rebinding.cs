using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rebinding : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputActionReference actionReference = null;
    [SerializeField] private TMP_Text actionButtonText = null;
    [SerializeField] private TMP_Text actionHintText = null;
    [SerializeField] private string bindName = null;
    
    private InputActionRebindingExtensions.RebindingOperation _RebindingOperation;

    private string _NameBeforeBind = null;

    private void Awake()
    {
        string bind = PlayerPrefs.GetString(actionHintText.text);

        if (bind.Length != 0)
        {
            actionReference.action.ApplyBindingOverride(bind);   
        }
        
        InitializeButtonText();
    }

    public void StartRebinding()
    {
        _NameBeforeBind = actionButtonText.text;
        actionButtonText.text = "...";
        
        actionReference.action.Disable();

        _RebindingOperation = actionReference.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .WithCancelingThrough("<Keyboard>/escape")
            .OnComplete(operation => RebindCompleted())
            .OnCancel(operation => RebindCancel());

        if (bindName.Length != 0)
        {
            _RebindingOperation.WithTargetBinding(GetBindindIndex());
            _RebindingOperation.WithExpectedControlType("Button");
        }

        _RebindingOperation.Start();
    }

    private void RebindCompleted()
    {
        int controlBindingIndex = GetBindindIndex();
        
        PlayerPrefs.SetString(actionHintText.text, actionReference.action.bindings[controlBindingIndex].overridePath);

        actionButtonText.text = InputControlPath.ToHumanReadableString(
            actionReference.action.bindings[controlBindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        
        _RebindingOperation.Dispose();
        _RebindingOperation = null;
    }

    private void RebindCancel()
    {
        actionButtonText.text = _NameBeforeBind;
        actionReference.action.Enable();
        
        _RebindingOperation.Dispose();
        _RebindingOperation = null;
    }
    
    private void InitializeButtonText()
    {
        actionButtonText.text = InputControlPath.ToHumanReadableString(
            actionReference.action.bindings[GetBindindIndex()].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    private int GetBindindIndex()
    {
        int controlBindingIndex = 0;

        if (bindName.Length == 0)
            controlBindingIndex = actionReference.action.GetBindingIndexForControl(actionReference.action.controls[0]);
        else
            controlBindingIndex = actionReference.action.bindings.IndexOf(x => x.isPartOfComposite && x.name == bindName);
        return controlBindingIndex;
    }
}
