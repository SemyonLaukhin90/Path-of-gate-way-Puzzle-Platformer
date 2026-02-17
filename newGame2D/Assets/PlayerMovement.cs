using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physic;

    public float moveSpeed = 7f;
    public float jumpForce = 30f;
    public bool isGround = false;

    public float rayDistance = 2f;

    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(physic.position, Vector2.down, rayDistance, LayerMask.GetMask("Grounds"));

        if (hit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        float moveInput = Input.GetAxis("Horizontal");
        physic.linearVelocity = new Vector2(moveInput * moveSpeed, physic.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            physic.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
