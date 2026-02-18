using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneTrigger : MonoBehaviour
{
    public static bool completeLevel = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player") completeLevel = true;
    }
}
