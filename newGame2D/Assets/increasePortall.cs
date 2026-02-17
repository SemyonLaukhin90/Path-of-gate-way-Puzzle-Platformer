using System.Collections.Generic;
using UnityEngine;

public class increasePortall : MonoBehaviour
{
    HashSet<string> uniqueNames = new HashSet<string>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!uniqueNames.Contains(collision.name))
        {
            collision.transform.localScale = new Vector2(collision.transform.localScale.x * 2, collision.transform.localScale.y * 2);
            uniqueNames.Add(collision.name);
        }
    }
}
