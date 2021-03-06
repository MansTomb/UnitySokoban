using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;

    private int _Score = 0;

    private void OnEnable()
    {
        scoreText.SetText($"Interaction to end: {_Score}");
        var prevScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 1000);
        
        if (_Score < prevScore)
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, _Score);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Completed", 1);
        PlayerPrefs.Save();
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void OnInteraction()
    {
        _Score++;
    }
    
    public void OnNext()
    {
        var scene = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (SceneManager.sceneCountInBuildSettings > scene)
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
