using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 5f;
    private int jumpsRemaining = 2; // Number of jumps remaining
    private bool isJumping = false;
    private bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * MoveSpeed, rb.velocity.y);

        // Check if the player is on the ground
        isGrounded = CheckGrounded();

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                isJumping = true;
                jumpsRemaining--;
            }
            else if (jumpsRemaining > 0 && !isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                isJumping = true;
                jumpsRemaining--;
            }
        }

        // Check if the player is falling down
        if (isGrounded && rb.velocity.y <= 0)
        {
            isJumping = false;
            jumpsRemaining = 2;
        }
    }

    private bool CheckGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + extraHeight);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jumps when landing on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumpsRemaining = 2;
        }
    }
}





