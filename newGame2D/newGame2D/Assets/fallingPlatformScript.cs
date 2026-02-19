using UnityEngine;

public class fallingPlatformScript : MonoBehaviour
{
    private Rigidbody2D physic;

    string[] brickNames = new string[] { "platform", "platform (1)", "platform (2)", "platform (3)", "platform (4)", "platform (5)", "platform (6)", "platform (7)" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        physic = collision.GetComponent<Rigidbody2D>();

        for (int i = 0; i < brickNames.Length; i++)
        {
            if (collision.name == brickNames[i])
            {
                physic.linearVelocity = new Vector2(physic.linearVelocity.x, -2);
                Destroy(collision.gameObject, 0.7f);
                break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        physic = null;
    }
}
