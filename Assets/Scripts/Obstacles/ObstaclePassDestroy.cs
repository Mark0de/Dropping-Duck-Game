using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePassDestroy : MonoBehaviour
{
    private void Update()
    {
        PassPlayer();
    }

    void PassPlayer() 
    {
        if (gameObject.transform.position.y > GameObject.FindGameObjectsWithTag("Player")[0].transform.position.y + 5)
        {
            gameObject.SetActive(false);
        }
    }
}
