using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public float pushPower = 2.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        rb.freezeRotation = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        player_movement player = collision.gameObject.GetComponent<player_movement>();
        if (player != null)
        {
            Vector2 pushDirection = collision.contacts[0].normal * -1;
            rb.velocity = pushDirection * pushPower;
        }
    }
}
