using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    float movingSpeed = 4f;
    float horizontalBoundaries = 1.85f;
    bool isLeft = true;

    private void Update()
    {
        if (GameManager.GameOver())
            return;

        Moving();
    }

    void Moving()
    {
        if (isLeft && transform.position.x >= -horizontalBoundaries)
        {
            transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
        } 
        else if (!isLeft && transform.position.x <= horizontalBoundaries) 
        {
            transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);
        }

        if (transform.position.x <= -horizontalBoundaries || transform.position.x >= horizontalBoundaries)
        {
            isLeft = !isLeft;
        }
    }
}
