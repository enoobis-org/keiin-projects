using UnityEngine;

public class PreventPassingThrough : MonoBehaviour
{
    private Collider2D col;

    void Start()
    {
        col = gameObject.AddComponent<BoxCollider2D>();
        col.isTrigger = false;
    }
}
