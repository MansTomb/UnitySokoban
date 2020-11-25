using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public void DeletePushHint()
    {
        Destroy(GameObject.Find("Push Hint"));
    }
}
