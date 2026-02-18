using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Uiscript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject diePanel;
    public GameObject victoryPanel;
    public bool show = false;

    public static bool playerDie = false;

    public static bool completeLevel = false;


    int levelNumber;

    private void Awake()
    {
        if (FindObjectsOfType<Uiscript>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        pausePanel.SetActive(false);
        diePanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    private void Update()
    {

        Scene activeScene = SceneManager.GetActiveScene();
        string sceneName = activeScene.name;

        levelNumber = GetNumberFromSceneName(sceneName);

        if (activeScene.name != "LevelsMenu" && activeScene.name != "MainMenu")
        {
            if (!ZoneTrigger.completeLevel)
            {
                victoryPanel.SetActive(false);
                if (!playerDie)
                {
                    diePanel.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        show = !show;

                        if (show)
                        {
                            pausePanel.SetActive(true);
                            Time.timeScale = 0f;
                        }
                        else
                        {
                            pausePanel.SetActive(false);
                            Time.timeScale = 1f;
                        }
                    }

                }
                else
                {
                    show = !show;
                    Time.timeScale = 1f;
                    pausePanel.SetActive(false);
                    diePanel.SetActive(true);
                }
            } else
            {
                pausePanel.SetActive(false);
                diePanel.SetActive(false);
                victoryPanel.SetActive(true);
            }
        }
        else
        {
            pausePanel.SetActive(false);
            diePanel.SetActive(false);
        }
    }

    private void Unpause()
    {
        show = !show;
        diePanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        playerDie = false;
        Unpause();
        victoryPanel.SetActive(false);
        if (ZoneTrigger.completeLevel) ZoneTrigger.completeLevel = false;
        SceneManager.LoadScene("Level " + levelNumber);
        
    }

    public void NextLevel()
    {
        playerDie = false;
        victoryPanel.SetActive(false);
        Unpause();
        if (ZoneTrigger.completeLevel) ZoneTrigger.completeLevel = false;
        SceneManager.LoadScene("Level " + (levelNumber + 1));
    }

    public void BackInMenu()
    {
        playerDie = false;
        victoryPanel.SetActive(false);
        diePanel.SetActive(false);
        if (ZoneTrigger.completeLevel) ZoneTrigger.completeLevel = false;
        SceneManager.LoadScene("LevelsMenu");
    }

    public void Continue() {
        if (ZoneTrigger.completeLevel) ZoneTrigger.completeLevel = false;
        Unpause();
    }

    private int GetNumberFromSceneName(string sceneName)
    {
        string digits = new string(sceneName.Where(c => char.IsDigit(c)).ToArray());
        if (int.TryParse(digits, out int number)) return number;
        else return 0;
        
    }
}
