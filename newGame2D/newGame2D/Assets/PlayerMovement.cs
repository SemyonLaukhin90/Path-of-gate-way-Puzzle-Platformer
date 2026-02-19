using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physic;

    public float moveSpeed = 7f;
    public float jumpForce = 30f;
    public bool isGround = false;

    public float rayDistance = 2f;

    private bool canjump = true;

    private bool canjump2 = false;

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
        if (!isGround)
        {
            canjump = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) && canjump && canjump2 && Time.timeScale == 1f)
            {
                Jump();
            }
        }
    }
    private void Jump()
    {
        canjump = false;
        physic.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        canjump2 = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canjump2 = false;
    }
}
