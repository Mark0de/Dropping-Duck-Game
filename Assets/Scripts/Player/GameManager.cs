using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    bool isGameOver = false;
    int gameoverLayer;
    Rigidbody2D rb;
    private void Awake()
    {
        instance = this;
        gameoverLayer = LayerMask.NameToLayer("Gameover");
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == gameoverLayer)
        {
            PlayerDied();
        }
    }

    public static bool GameOver()
    {
        return instance.isGameOver;
    }

    public static void PlayerDied() 
    {
        instance.rb.bodyType = RigidbodyType2D.Static;
        instance.isGameOver = true;
        instance.Invoke("RestartScene", 1.5f);
    }

    void RestartScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
