using System.Collections.Generic;
using UnityEngine;

public class fanScript : MonoBehaviour
{
    private List<Rigidbody2D> objectsPhysicList = new List<Rigidbody2D>();

    public float fanForceY = 0.3f;
    public float fanForceX = 0.3f;
    
    private void FixedUpdate()
    {
        
        foreach (var rb in objectsPhysicList)
        {
            if (rb != null)
            {
                rb.AddForce(new Vector2(fanForceX, fanForceY), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null && !objectsPhysicList.Contains(rb))
        {
            objectsPhysicList.Add(rb);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null && objectsPhysicList.Contains(rb))
        {
            objectsPhysicList.Remove(rb);
        }
    }
}
