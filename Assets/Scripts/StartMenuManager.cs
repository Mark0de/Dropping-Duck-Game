using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    Rigidbody2D rb;
    bool isFliped = false;
    bool isGameStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("FlipDirection", 0.5f, 0.5f);
    }

    private void Update()
    {
        TapScreenToStart();
        LoopFalling();
    }

    void FlipDirection()
    {
        rb.velocity = new Vector2(rb.velocity.x, -5f);
        if (!isFliped)
        {
            transform.localScale = new Vector3(1, -1, 1);
            isFliped = !isFliped;
        }
        else if (isFliped)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFliped = !isFliped;
        }
    }

    void LoopFalling() 
    {
        if (transform.position.y <= -6)
        {
            transform.Translate(new Vector2(0, 12));
        }
    }

    void TapScreenToStart() 
    {
        if (Input.GetMouseButton(0))
        {
            if (!isGameStarted)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                isGameStarted = true;
            }
        }
    }
}
