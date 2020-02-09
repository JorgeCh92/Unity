using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Variables
    Rigidbody2D rb;
    float dirX;
    float dirY;
    float moveSpeed = 20f;

    //Movimiento del jugador dependiendo del giro del móvil
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;
        dirY = Input.acceleration.y * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -11f, 11f), Mathf.Clamp(transform.position.y, -5f, 5f));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    //Cuando el jugador choca con un enemigo pierde la partida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.gameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.gameOver();
        }
    }
}
