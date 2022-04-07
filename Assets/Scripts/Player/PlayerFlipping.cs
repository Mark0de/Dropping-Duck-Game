using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipping : MonoBehaviour
{
    public bool isFliped = false;
    public LayerMask enemiesLayer;
    public PlayerDropping playerDroppingScript;

    float flipTime = 0.2f;
    float verticalOffset = 0.5f;
    float horizontalOffset = 0.6f;
    float rayLength = 0.15f;

    private void Update()
    {
        if (GameManager.GameOver()) 
        { 
            CancelInvoke("FlipDirection"); 
            return; 
        }

        //1. Invoke Flipping 2.When isHeld -> Stop Flipping 3. When isNotHeld -> Restart Flipping
        if (!IsInvoking("FlipDirection") && playerDroppingScript.isHeld == false)
        {
            InvokeRepeating("FlipDirection", flipTime, flipTime);
        }
        else if (playerDroppingScript.isHeld == true)
        {
            CancelInvoke("FlipDirection");
        }
    }

    private void FixedUpdate()
    { 
        if (GameManager.GameOver())
            return;

        HeadHitGroundChecking();
    }

    void FlipDirection() 
    {
        if (!isFliped)
        {
            transform.localScale = new Vector3(1, -1, 1);
            isFliped = !isFliped;
        }
        else if (isFliped)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFliped = !isFliped;
        }
    }

    void HeadHitGroundChecking()
    {
        RaycastHit2D LeftbottomCheck = Raycast(new Vector2(-horizontalOffset, -verticalOffset), Vector2.down, rayLength, enemiesLayer);
        RaycastHit2D RightbottomCheck = Raycast(new Vector2(horizontalOffset, -verticalOffset), Vector2.down, rayLength, enemiesLayer);

        if ((LeftbottomCheck || RightbottomCheck) && isFliped)
        {
            GameManager.PlayerDied();
        }
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.green : Color.red;
        Debug.DrawRay(pos + offset, rayDirection * length, color);
        return hit;
    }
}
