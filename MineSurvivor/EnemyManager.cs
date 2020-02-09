using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    //Variables
    Vector3 randomPosition;
    private float speedGhost = 0.07f;
    private float speedZombie = 0.03f;
    private float speedWolf = 1.5f;
    private string directionWolf = "left";
    Vector3 newPosition;
    Transform player;

    void Awake()
    {
        player= GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        //El Ghost de mueve de forma aleatoria
        if (this.name == "Ghost")
        {
            if (Vector2.Distance(transform.position, newPosition) < 1)
            {
                newPosition = new Vector2(Random.Range(-11.0f, 11.0f), Random.Range(-5.0f, 5.0f));
            }

            transform.position = Vector3.Lerp(transform.position, newPosition, speedGhost);
        }

        //El Zombie se dedica a perseguir lentamente al jugador
        if (this.name == "Zombie")
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speedZombie);
        }

        //El Wolf se mueve de forma horizontal constantemente en el centro
        if (this.name == "Wolf")
        {
            if(directionWolf.Equals("left"))
            {
                transform.position = Vector3.Lerp(transform.position, new Vector2(-8, 0), speedWolf * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector2(8, 0), speedWolf * Time.deltaTime);
            }
            

            if ((int)transform.position.x < -6)
            {
                directionWolf = "right";
            }
            if ((int)transform.position.x > 6)
            {
                directionWolf = "left";
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.name == "Ghost")
        {
            //Control de las colisiones del enemigo con el escenario
            if (collision.gameObject.name == "GroundTop")
            {
                newPosition = new Vector2(Random.Range(-11.0f, 11.0f), Random.Range(-5.0f, 0f));
            }
            else if (collision.gameObject.name == "GroundBottom")
            {
                newPosition = new Vector2(Random.Range(-11.0f, 11.0f), Random.Range(0f, 5f));
            }
            else if (collision.gameObject.name == "GroundLeft")
            {
                newPosition = new Vector2(Random.Range(0f, 11.0f), Random.Range(-5.0f, 5f));
            }
            else if (collision.gameObject.name == "GroundRigth")
            {
                newPosition = new Vector2(Random.Range(-11.0f, 0f), Random.Range(-5.0f, 5f));
            }
        }
    }
}
