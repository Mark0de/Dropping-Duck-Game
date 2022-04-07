using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncing : MonoBehaviour
{
    static PlayerBouncing instance;

    bool isCollided = false;
    bool isHitted = false;
    Rigidbody2D rb;
    float upwardVelocity = 8f;
    float delayTime = 0.25f;
    int enemiesLayer;
    int obstaclesKilledNum = 0;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        enemiesLayer = LayerMask.NameToLayer("Enemies");
    }

    private void Update()
    {
        if (GameManager.GameOver())
            return;

        SpawnObstacleWhenOneIsKilled();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemiesLayer)
        {
            isCollided = true;
            isHitted = true;
            StartCoroutine(IncrementKilledNumAfterTime(delayTime));
            Invoke("SetBoolBack", 0.5f);
            rb.velocity = new Vector2(rb.velocity.x, upwardVelocity);//這個不會越跳越低
            //rb.AddForce(transform.up * upwardForce, ForceMode2D.Impulse);
        }
    }

    public static bool PlayerCollided() 
    {
        return instance.isCollided;
    }

    public static int ObstaclesKilled()
    {
        return instance.obstaclesKilledNum;
    }

    void SetBoolBack() 
    {
        isCollided = false;
    }

    IEnumerator IncrementKilledNumAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (!GameManager.GameOver())
        {
            obstaclesKilledNum++;
        }
    }

    void SpawnObstacleWhenOneIsKilled()
    {
        if (isHitted)
        {
            ObstacleSpawner.SpawnOneObstacle();
            isHitted = false;
        }
    }
}
