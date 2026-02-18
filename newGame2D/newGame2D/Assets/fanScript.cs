using System.Collections.Generic;
using UnityEngine;

public class fanScript : MonoBehaviour
{
    public float fanForce = 70f;
    private List<Rigidbody2D> objectsPhysicList = new List<Rigidbody2D>();

    private void Update()
    {
        Vector2 forceDirection = new Vector2(0, 1).normalized;
        foreach (var rb in objectsPhysicList)
        {
            if (rb != null)
            {
                rb.AddForce(forceDirection * fanForce * Time.deltaTime, ForceMode2D.Impulse);
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
