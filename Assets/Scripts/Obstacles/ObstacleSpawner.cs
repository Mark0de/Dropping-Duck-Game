using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    static ObstacleSpawner instance;
    public GameObject obstaclePrefab;
    int obstaclesNum = 5;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < obstaclesNum; i++)
        {
            Instantiate(obstaclePrefab, new Vector2(Random.Range(-1.85f, 1.85f), i * -2f), Quaternion.identity);
        }
    }

    public static void SpawnOneObstacle() 
    {
        Instantiate(instance.obstaclePrefab, new Vector2(Random.Range(-1.85f, 1.85f), instance.obstaclesNum * -2f), Quaternion.identity);
        instance.obstaclesNum++;
    }

}
