using UnityEngine;

public class openDoor3 : MonoBehaviour
{
    private GameObject button;
    private GameObject button2;

    private GameObject door;
    private bool openDor = false;
    private float openProgress = 0f;
    public float openSpeed = 2f;


    private SpriteRenderer renderer;
    private SpriteRenderer renderer2;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    public float rotate = -80f;


    private void Start()
    {
        button = GameObject.Find("Button (4)");
        button2 = GameObject.Find("Button (5)");
        renderer = button.GetComponent<SpriteRenderer>();
        renderer2 = button2.GetComponent<SpriteRenderer>();
        door = GameObject.Find("circleForDoor3");
        renderer.enabled = false;

        closedRotation = door.transform.rotation;
        openRotation = door.transform.rotation * Quaternion.Euler(0, 0, rotate);
    }

    private void Update()
    {
        if (openDor)
        {
            renderer2.enabled = true;
            renderer.enabled = false;
            if (openProgress < 1f)
            {
                openProgress += Time.deltaTime * openSpeed;
                if (openProgress > 1f) openProgress = 1f;
            }
        }
        else
        {
            renderer2.enabled = false;
            renderer.enabled = true;
            if (openProgress > 0f)
            {
                openProgress -= Time.deltaTime * openSpeed;
                if (openProgress < 0f) openProgress = 0f;
            }
        }

        door.transform.rotation = Quaternion.Lerp(closedRotation, openRotation, openProgress);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        openDor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openDor = false;
    }
}
