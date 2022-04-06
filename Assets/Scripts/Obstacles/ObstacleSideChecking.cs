using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSideChecking : MonoBehaviour
{
    public LayerMask playerLayer;
    float sideOffset = 1;
    float rayLength = 0.1f;
    float longRayLength = 3f;
    bool isPlayerPassed = false;

    private void FixedUpdate()
    {
        if (GameManager.GameOver())
            return;

        KillPlayerSideChecking();
        SpawnObstacleSideChecking();
    }

    void KillPlayerSideChecking()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-sideOffset, 0f), Vector2.left, rayLength, playerLayer);
        RaycastHit2D rightCheck = Raycast(new Vector2(sideOffset, 0f), Vector2.right, rayLength, playerLayer);

        if (leftCheck || rightCheck)
        {
            GameManager.PlayerDied();
        }
    }

    void SpawnObstacleSideChecking() 
    {
        RaycastHit2D LeftSideCheck = Raycast(new Vector2(-sideOffset, 0f), Vector2.left, longRayLength, playerLayer);
        RaycastHit2D RightSideCheck = Raycast(new Vector2(sideOffset, 0f), Vector2.right, longRayLength, playerLayer);

        if (!isPlayerPassed)
        {
            if (LeftSideCheck || RightSideCheck)
            {
                ObstacleSpawner.SpawnOneObstacle();
                isPlayerPassed = true;
            }
        }
        else if (isPlayerPassed)
        {
            Invoke("ActivateRay", 0.5f);
        }
    }

    void ActivateRay() 
    {
        isPlayerPassed = false;
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
