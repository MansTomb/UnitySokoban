using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controls : MonoBehaviour
{
    [SerializeField] private Rebinding[] rebindings;

    public UnityEvent<string, string> onButtonRebind;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.00001f);

        foreach (var rebindButton in rebindings)
        {
            rebindButton.rebindWasCompleted += (action, button) => onButtonRebind?.Invoke(action, button);
        }
        gameObject.SetActive(false);
    }
    
    
}
