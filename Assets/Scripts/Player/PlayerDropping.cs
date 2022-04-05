using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropping : MonoBehaviour
{
    Rigidbody2D rb;
    float downwardForce = 15f;
    public bool isHeld = false;
    public PlayerBouncing playerBouncingScript;

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
        if (Input.GetMouseButton(1) && rb.bodyType == RigidbodyType2D.Dynamic && playerBouncingScript.isCollided == false)
        {
            isHeld = true;
            rb.velocity = new Vector2(rb.velocity.x, -downwardForce);
        }
        else 
        {
            isHeld = false;
        }
    }
}
