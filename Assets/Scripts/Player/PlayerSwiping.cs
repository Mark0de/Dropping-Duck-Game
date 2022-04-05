using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwiping : MonoBehaviour
{
    private int desiredLane = 1; //0: Left, 1: Middle, 2: Right
    public float laneDistance = 4f; //The distance between two lanes
    private float switchLaneSpeed = 80f;

    void Update()
    {
        if (GameManager.GameOver())
            return;

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        else if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        Vector2 targetPosition = transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector2.left * laneDistance; 
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector2.right * laneDistance;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, switchLaneSpeed * Time.deltaTime);
    }
}