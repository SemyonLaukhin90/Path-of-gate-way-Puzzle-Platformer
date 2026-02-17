using UnityEngine;
using UnityEngine.SceneManagement;

public class diedScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level 1":
                    SceneManager.LoadScene("Level 1");
                    break;
                case "Level 2":
                    SceneManager.LoadScene("Level 2");
                    break;
                case "Level 3":
                    SceneManager.LoadScene("Level 3");
                    break;
                case "Level 4":
                    SceneManager.LoadScene("Level 4");
                    break;
                case "Level 5":
                    SceneManager.LoadScene("Level 5");
                    break;
                case "Level 6":
                    SceneManager.LoadScene("Level 6");
                    break;
                case "Level 7":
                    SceneManager.LoadScene("Level 7");
                    break;
                case "Level 8":
                    SceneManager.LoadScene("Level 8");
                    break;
                case "Level 9":
                    SceneManager.LoadScene("Level 9");
                    break;
                case "Level 10":
                    SceneManager.LoadScene("Level 10");
                    break;
                case "Level 11":
                    SceneManager.LoadScene("Level 11");
                    break;
                case "Level 12":
                    SceneManager.LoadScene("Level 12");
                    break;
                case "Level 13":
                    SceneManager.LoadScene("Level 13");
                    break;
                case "Level 14":
                    SceneManager.LoadScene("Level 14");
                    break;
                case "Level 15":
                    SceneManager.LoadScene("Level 14");
                    break;
            }
        }
    }
}
