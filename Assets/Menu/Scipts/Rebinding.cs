using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rebinding : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputActionReference actionReference = null;
    [SerializeField] private TMP_Text actionButtonText = null;
    [SerializeField] private string bindName = null;
    
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Awake()
    {
        SetTextToButtonName();
    }

    public void StartRebinding()
    {
        int bindingIndex = 0;
        actionButtonText.text = "...";
        
        actionReference.action.Disable();

        if (bindName.Length != 0)
        {
            bindingIndex = actionReference.action.bindings.IndexOf(x => x.isPartOfComposite && x.name == bindName);
        }

        rebindingOperation = actionReference.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindCompleted())
            .OnCancel(operation => SetTextToButtonName());

        if (bindName.Length != 0)
        {
            rebindingOperation.WithTargetBinding(bindingIndex);
            rebindingOperation.WithExpectedControlType("Button");
        }

        rebindingOperation.Start();
    }

    private void RebindCompleted()
    {
        SetTextToButtonName();
        rebindingOperation.Dispose();
        rebindingOperation = null;
    }

    private void SetTextToButtonName()
    {
        int controlBindingIndex = 0;

        if (bindName.Length == 0)
            controlBindingIndex = actionReference.action.GetBindingIndexForControl(actionReference.action.controls[0]);
        else
            controlBindingIndex = actionReference.action.bindings.IndexOf(x => x.isPartOfComposite && x.name == bindName);

        actionButtonText.text = InputControlPath.ToHumanReadableString(
            actionReference.action.bindings[controlBindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        
        actionReference.action.Enable();
    }
}
