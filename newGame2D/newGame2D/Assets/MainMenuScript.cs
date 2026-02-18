using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PressPlay()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
    public void PressSettings()
    {
        //SceneManager.LoadScene("SettingsMenu");
    }
    public void PressExit()
    {
        Application.Quit();
    }
}
