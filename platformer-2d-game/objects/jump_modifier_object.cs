using UnityEngine;

public class JumpModifier : MonoBehaviour
{
    public float jumpChange = 5f;
    private float originalJumpPower;
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
            originalJumpPower = playerMovement.jumpPower;
            playerMovement.jumpPower += jumpChange;
            Invoke("ResetJumpPower", 5f);
        }
    }

    void ResetJumpPower()
    {
        if (playerMovement != null)
        {
            playerMovement.jumpPower = originalJumpPower;
        }
    }
}
