using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;

public class BoxFinish : MonoBehaviour
{
    public delegate void BoxEnteredFinish();
    public delegate void BoxExitFinish();
    
    public event BoxEnteredFinish boxEnter;
    public event BoxExitFinish boxExit;
    
    [SerializeField] private Color _NeedColorToFinish;

    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", _NeedColorToFinish);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger || !other.CompareTag("Box"))
            return;
        if (other.gameObject.GetComponent<Renderer>().material.GetColor("_BaseColor") == _NeedColorToFinish)
        {
            boxEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger || !other.CompareTag("Box"))
            return;
        if (other.gameObject.GetComponent<Renderer>().material.GetColor("_BaseColor") == _NeedColorToFinish)
        {
            boxExit?.Invoke();
        }
    }
}
