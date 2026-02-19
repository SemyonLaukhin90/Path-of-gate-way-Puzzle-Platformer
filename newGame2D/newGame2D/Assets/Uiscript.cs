using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Uiscript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject diePanel;
    public GameObject victoryPanel;
    public bool show = false;

    public static bool playerDie = false;

    public static bool completeLevel = false;

    int levelNumber;

    private bool[] levelsStatus = new bool[16] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    private Button Level1;
    private Button Level2;
    private Button Level3;
    private Button Level4;
    private Button Level5;
    private Button Level6;
    private Button Level7;
    private Button Level8;
    private Button Level9;
    private Button Level10;
    private Button Level11;
    private Button Level12;
    private Button Level13;
    private Button Level14;
    private Button Level15;

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
        
        if (sceneName == "LevelsMenu")
        {
            Level1 = GameObject.Find("Level1").GetComponent<Button>();
            Level2 = GameObject.Find("Level2").GetComponent<Button>();
            Level3 = GameObject.Find("Level3").GetComponent<Button>();
            Level4 = GameObject.Find("Level4").GetComponent<Button>();
            Level5 = GameObject.Find("Level5").GetComponent<Button>();
            Level6 = GameObject.Find("Level6").GetComponent<Button>();
            Level7 = GameObject.Find("Level7").GetComponent<Button>();
            Level8 = GameObject.Find("Level8").GetComponent<Button>();
            Level9 = GameObject.Find("Level9").GetComponent<Button>();
            Level10 = GameObject.Find("Level10").GetComponent<Button>();
            Level11 = GameObject.Find("Level11").GetComponent<Button>();
            Level12 = GameObject.Find("Level12").GetComponent<Button>();
            Level13 = GameObject.Find("Level13").GetComponent<Button>();
            Level14 = GameObject.Find("Level14").GetComponent<Button>();
            Level15 = GameObject.Find("Level15").GetComponent<Button>();
            Button[] levels = new Button[] { Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, Level10, Level11, Level12, Level13, Level14, Level15 };
            for (int i = 0; i < levels.Length; i++)
            {
                if (levelsStatus[i]) levels[i + 1].interactable = true;
            }
        }


        if (sceneName != "LevelsMenu" && sceneName != "MainMenu")
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
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
                diePanel.SetActive(false);
                victoryPanel.SetActive(true);
                if (sceneName == "Level " + levelNumber)
                {
                    levelsStatus[levelNumber - 1] = true;
                }
            }
        }
        else
        {
            Time.timeScale = 1f;
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
        show = !show;
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
