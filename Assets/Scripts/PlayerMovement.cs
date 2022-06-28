using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movementSpeed;
    [SerializeField] private int jumpSpeed;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerBody;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        playerBody.velocity = new Vector2(horizontalInput * movementSpeed, playerBody.velocity.y);

        if (IsGrounded())
        {
            playerBody.velocity = Vector2.up * jumpSpeed;
        }

        ScoreScript.scoreValue = playerBody.position.y;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}
