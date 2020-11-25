using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent<GameObject> _Interaction = new UnityEvent<GameObject>();

    public void Interact(GameObject Player)
    {
        _Interaction?.Invoke(Player);
    }
}
