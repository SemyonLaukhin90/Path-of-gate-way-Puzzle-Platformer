using UnityEngine;
using UnityEngine.SceneManagement;

public class loadUI : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);

    }
}
