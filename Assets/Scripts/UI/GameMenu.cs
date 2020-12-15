using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
    public void OnExitGame() {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
