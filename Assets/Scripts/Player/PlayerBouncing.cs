using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncing : MonoBehaviour
{
    public bool isCollided = false;
    Rigidbody2D rb;
    float upwardForce = 8f;
    int enemiesLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemiesLayer = LayerMask.NameToLayer("Enemies");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemiesLayer)
        {
            isCollided = true;
            Invoke("SetBoolBack", 1f);
            rb.velocity = new Vector2(rb.velocity.x, upwardForce);//這個不會越跳越低
            //rb.AddForce(transform.up * upwardForce, ForceMode2D.Impulse);
        }
    }

    void SetBoolBack() 
    {
        isCollided = false;
    }
}
