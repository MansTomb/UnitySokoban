using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] public string scenePath = null;
    [SerializeField] private TMP_Text levelName = null;
    [SerializeField] private TMP_Text levelScore = null;
    [SerializeField] private TMP_Text levelCompleted = null;

    private string sceneName = null;
    
    private void Awake()
    {
        sceneName = Path.GetFileNameWithoutExtension(scenePath);
        
        levelName.SetText(sceneName);
        
        var score = PlayerPrefs.GetInt(sceneName, 1000);
        levelScore.SetText($"Interaction to win: {score}");

        var completed = PlayerPrefs.GetInt(sceneName + "Completed", 0);
        levelCompleted.SetText(completed == 1 ? "Completed" : "Not Completed");
    }

    public void OnScenePlayed()
    {
        SceneManager.LoadScene(sceneName);
    }
}
