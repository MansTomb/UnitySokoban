using UnityEngine;
using UnityEngine.Serialization;

public class BoxFinish : MonoBehaviour
{
    public delegate void BoxEnteredFinish();
    public delegate void BoxExitFinish();
    
    public event BoxEnteredFinish boxEnter;
    public event BoxExitFinish boxExit;

    [FormerlySerializedAs("_NeedColorToFinish")] [SerializeField] private Color needColorToFinish = Color.black;

    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", needColorToFinish);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger || !other.CompareTag("Box"))
            return;
        if (other.gameObject.GetComponent<Renderer>().material.GetColor("_BaseColor") == needColorToFinish)
        {
            other.gameObject.GetComponent<BoxParticle>().OnFinishEnter();
            boxEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger || !other.CompareTag("Box"))
            return;
        if (other.gameObject.GetComponent<Renderer>().material.GetColor("_BaseColor") == needColorToFinish)
        {
            other.gameObject.GetComponent<BoxParticle>().OnFinishExit();
            boxExit?.Invoke();
        }
    }
}
