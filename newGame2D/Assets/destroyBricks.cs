using Unity.VisualScripting;
using UnityEngine;

public class destroyBricks : MonoBehaviour
{
    string[] brickNames = new string[] { "Square", "Square (1)", "Square (2)", "Square (3)" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < brickNames.Length; i++)
        {
            if (collision.name == brickNames[i])
            {
                Destroy(collision.gameObject);
                break;
            }
        }
    }
}
