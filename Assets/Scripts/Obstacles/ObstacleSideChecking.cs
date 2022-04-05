using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSideChecking : MonoBehaviour
{
    public LayerMask playerLayer;
    public float sideOffset;
    public float rayLength;

    private void FixedUpdate()
    {
        SideChecking();
    }

    void SideChecking()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-sideOffset, 0f), Vector2.left, rayLength, playerLayer);
        RaycastHit2D rightCheck = Raycast(new Vector2(sideOffset, 0f), Vector2.right, rayLength, playerLayer);

        if (leftCheck || rightCheck)
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
