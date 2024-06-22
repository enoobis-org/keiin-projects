using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    public float speedChange = 5f;
    private float originalSpeed;
    private player_movement playerMovement;

    void Start()
    {
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement = other.GetComponent<player_movement>();
        if (playerMovement != null)
        {
            originalSpeed = playerMovement.speed;
            playerMovement.speed += speedChange;
            Invoke("ResetSpeed", 5f);
        }
    }

    void ResetSpeed()
    {
        if (playerMovement != null)
        {
            playerMovement.speed = originalSpeed;
        }
    }
}
