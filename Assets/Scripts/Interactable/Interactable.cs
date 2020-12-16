using UnityEngine;

public class Interactable : MonoBehaviour
{
    public delegate void Interaction(GameObject go);
    public event Interaction OnInteraction;
    
    public void Interact(GameObject Player)
    {
        OnInteraction?.Invoke(Player);
    }
}
