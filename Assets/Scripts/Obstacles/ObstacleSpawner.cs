using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public ObstacleColliding obstacleCollidingScript;
    int startObstacleNumber = 5;

    void Start()
    {
        for (int i = 0; i < startObstacleNumber; i++)
        {
            Instantiate(obstaclePrefab, new Vector2(Random.Range(-1.85f, 1.85f), i * -2f), Quaternion.identity);
        }
    }

    private void Update()
    {
        
    }

    void SpawnMoreObstacles() 
    {

    }
}
