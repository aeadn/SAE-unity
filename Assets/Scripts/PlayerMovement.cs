using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f; 
    public float moveDirectionX = 0f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public bool isGrounded = false;
    public LayerMask listGroundLayers;
    public int maxAllowedJumps = 3;
    public int currentNumberJumps = 0;
    public bool isFacingRight = true;
    public VoidEventChannel onPlayerDeath;

    private void OnEnable() {
        onPlayerDeath.OnEventRaised += Die;
    }

    private void OnDisable() {
        onPlayerDeath.OnEventRaised -= Die;
    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Die() {
        enabled = false;
    }

    void Flip() {
        if ((moveDirectionX > 0 && !isFacingRight) || (moveDirectionX < 0 && isFacingRight)) {
            transform.Rotate(0,180,0);
            isFacingRight = !isFacingRight;
        }
    }
    // Update is called once per frame
    void Update()    
    {
        
        moveDirectionX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && currentNumberJumps < maxAllowedJumps) {
            Jump();
            currentNumberJumps++;
        }
        if (
            isGrounded &&
            !Input.GetButton("Jump")
        ) {
            currentNumberJumps = 0;
        }
        Flip();
    }

    private void Jump() {
        rb.linearVelocity = new Vector2 (
            rb.linearVelocity.x,
            jumpForce
        );
    }
    private void FixedUpdate() {
        rb.linearVelocity = new Vector2 (
            moveDirectionX * moveSpeed,
            rb.linearVelocity.y
        );
        isGrounded = IsGrounded();
    }

    public bool IsGrounded() {
        return Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            listGroundLayers
        );
    }
    private void OnDrawGizmos() {
        if (groundCheck != null){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }
    }
}
