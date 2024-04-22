using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_object : MonoBehaviour
{
    void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }

        collider.isTrigger = false;
    }
    void Update()
    {
    }
}