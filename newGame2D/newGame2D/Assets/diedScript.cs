using UnityEngine;
using UnityEngine.SceneManagement;

public class diedScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Uiscript.playerDie = true;
            Destroy(collision.gameObject);
        }
        
    }
}
