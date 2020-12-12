using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
