using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private SceneAsset scene = null;
    [SerializeField] private TMP_Text levelName = null;
    [SerializeField] private TMP_Text levelScore = null;
    [SerializeField] private TMP_Text levelCompleted = null;

    private void Awake()
    {
        levelName.SetText(scene.name);
        
        var score = PlayerPrefs.GetFloat(scene.name, 0);
        levelScore.SetText($"Interaction to win: {score}");

        var completed = PlayerPrefs.GetInt(scene.name + "Completed", 0);
        levelCompleted.SetText(completed == 1 ? "Completed" : "Not Completed");
    }

    public void OnScenePlayed()
    {
        SceneManager.LoadScene(scene.name);
    }
}
