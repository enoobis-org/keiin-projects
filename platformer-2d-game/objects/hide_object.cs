using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private Collider2D platformCollider;
    private Renderer platformRenderer;
    private bool playerOnPlatform = false;
    private float timeOnPlatform = 0f;
    public float requiredTimeOnPlatform = 2f;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        platformRenderer = GetComponent<Renderer>();

        if (platformCollider == null)
        {
            platformCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        if (platformRenderer == null)
        {
            platformRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        platformCollider.isTrigger = false;
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            timeOnPlatform += Time.deltaTime;
            if (timeOnPlatform >= requiredTimeOnPlatform)
            {
                StartCoroutine(DisappearAndReappear());
                playerOnPlatform = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<player_movement>() != null)
        {
            playerOnPlatform = true;
            timeOnPlatform = 0f; // Reset the timer when the player steps on the platform
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<player_movement>() != null)
        {
            playerOnPlatform = false;
            timeOnPlatform = 0f; // Reset the timer when the player steps off the platform
        }
    }

    private IEnumerator DisappearAndReappear()
    {
        platformRenderer.enabled = false;
        platformCollider.enabled = false;
        yield return new WaitForSeconds(5f);
        platformRenderer.enabled = true;
        platformCollider.enabled = true;
    }
}
