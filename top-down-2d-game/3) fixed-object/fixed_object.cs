using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixed_object : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.bodyType = RigidbodyType2D.Static;
    }
}
