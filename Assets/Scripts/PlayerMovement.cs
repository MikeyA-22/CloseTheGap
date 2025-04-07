using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Ground Check Settings")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    bool IsGrounded()
    {
        // Cast a box just below the player's collider to detect ground
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center,
                                             boxCollider.bounds.size,
                                             0f,
                                             Vector2.down,
                                             groundCheckDistance,
                                             groundLayer);
        return hit.collider != null;
    }

    // Optional: visualize the boxcast in Scene view
    private void OnDrawGizmosSelected()
    {
        if (boxCollider == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + Vector3.down * groundCheckDistance,
                            boxCollider.bounds.size);
    }
}
