using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
