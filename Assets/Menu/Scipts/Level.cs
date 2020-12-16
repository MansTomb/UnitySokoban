using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private SceneAsset scene = null;
    
    public void OnScenePlayed()
    {
        SceneManager.LoadScene(scene.name);
    }
}
