using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void LateUpdate()
    {
        if (player) transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z);
    }
}
