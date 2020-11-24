using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent _Interaction = new UnityEvent();

    public void RegisterInteractionHandler(UnityAction Handler)
    {
        _Interaction.AddListener(Handler);
    }
}
