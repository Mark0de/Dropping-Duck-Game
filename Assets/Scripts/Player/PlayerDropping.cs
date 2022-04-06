using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropping : MonoBehaviour
{
    Rigidbody2D rb;
    float downwardVelocity = 15f;
    public bool isHeld = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        Invoke("DropAfterFewSeconds", 3f);
    }

    private void Update()
    {
        HoldToDrop();
    }

    void DropAfterFewSeconds() 
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void HoldToDrop() 
    {
        if (Input.GetMouseButton(0) && rb.bodyType == RigidbodyType2D.Dynamic && !PlayerBouncing.PlayerCollided())
        {
            isHeld = true;
            rb.velocity = new Vector2(rb.velocity.x, -downwardVelocity);
        }
        else 
        {
            isHeld = false;
        }
    }
}
