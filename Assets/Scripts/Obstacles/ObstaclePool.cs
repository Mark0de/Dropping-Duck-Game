using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public static ObstaclePool SharedInstance;
    public List<GameObject> pooledObstacles;
    public GameObject obstacleToPool;
    int amountToPool = 10;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObstacles = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(obstacleToPool);
            tmp.SetActive(false);
            pooledObstacles.Add(tmp);
        }
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObstacles[i].activeInHierarchy)
            {
                return pooledObstacles[i];
            }
        }
        return null;
    }
}
