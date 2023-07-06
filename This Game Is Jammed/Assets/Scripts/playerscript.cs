using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 5f;
    public bool IsJumping { get; private set; } = false;
    public bool IsGrounded { get; private set; } = false;
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * MoveSpeed, rb.velocity.y);

        // Check if the player is on the ground
        IsGrounded = CheckGrounded();

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded || !IsJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                IsJumping = true;
            }
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
        // Reset IsJumping flag when landing on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }
}


