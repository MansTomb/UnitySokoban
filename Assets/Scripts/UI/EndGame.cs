using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;

    private int _Score = 0;

    private void OnEnable()
    {
        scoreText.SetText($"Interaction to end: {_Score}");
        var prevScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0);
        
        if (_Score < prevScore)
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, _Score);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Completed", 1);
        PlayerPrefs.Save();
    }

    public void OnInteraction()
    {
        _Score++;
    }
    
    public void OnNext()
    {
        var scene = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (SceneManager.sceneCount >= scene)
            SceneManager.LoadScene(scene);
        else
            OnMainMenu();
    }
    
    public void OnReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
    public void OnExitGame() {
        Application.Quit();
    }
}
