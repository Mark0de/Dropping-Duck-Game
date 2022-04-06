using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColliding : MonoBehaviour
{
    int playerLayer;
    float delayTime = 0.25f;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            StartCoroutine(DestroyAfterTime(delayTime));
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (!GameManager.GameOver())
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
