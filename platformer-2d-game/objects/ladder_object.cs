using UnityEngine;

public class Ladder : MonoBehaviour
{
    private BoxCollider2D ladderCollider;

    void Start()
    {
        ladderCollider = gameObject.AddComponent<BoxCollider2D>();
        ladderCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player_movement player = other.GetComponent<player_movement>();
        if (player != null)
        {
            player.isNearLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player_movement player = other.GetComponent<player_movement>();
        if (player != null)
        {
            player.isNearLadder = false;
        }
    }
}
