using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;
    public int maxJumpCount = 2;
    public float climbSpeed = 3f;
    public bool isNearLadder = false;
    private bool isClimbing = false;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 2;
        rb.freezeRotation = true;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (isNearLadder && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            isClimbing = true;
        }
        else if (!isNearLadder || isGrounded)
        {
            isClimbing = false;
        }

        if (isClimbing)
        {
            float climb = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(move * speed, climb * climbSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
            rb.gravityScale = 2;

            if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpCount++;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count when grounded
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = false;
        }
    }
}
