using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    void Start()
    {
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player_movement player = other.GetComponent<player_movement>();
        if (player != null)
        {
            Destroy(player.gameObject);
        }
    }
}
