using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolate : MonoBehaviour
{
    // La barra de chocolate aplasta al jugador y es capas de reflejar sus balas

    bool Vandera = true;

    private void Update()
    {
        if (Vandera)
        {
            RaycastHit2D Dec = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 4.5f, LayerMask.GetMask("Jugador"));

            if (Dec.collider != null)
            {
                Vector3 Scalor = transform.localScale;
                Scalor.x *= 1;
                transform.localScale = Scalor;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                Vandera = false;
            }

            RaycastHit2D Dec2 = Physics2D.Raycast(gameObject.transform.position, Vector2.left, 4.5f, LayerMask.GetMask("Jugador"));

            if (Dec2.collider != null)
            {
                Vector3 Scalor = transform.localScale;
                Scalor.x *= -1;
                transform.localScale = Scalor;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                Vandera = false;
            }
        }
       
    }

    // Cuando algo colicione con la barra 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# de las balas del jugador
        Bullets Bala = collision.gameObject.GetComponent<Bullets>();

        // Se compurela que lo que toco a la barra sea una bala del jugador
        if (Bala != null)
        {
            // Se toma referencia del componente RigiBody2d de la balas del jugador
            Rigidbody2D BalaRigy = Bala.gameObject.GetComponent<Rigidbody2D>();

            // Se utiliza la funcionde AddForce para disparar la bala
            // Se toma referencia de la direcion de la bala y se invierte
            BalaRigy.AddForce(-Bala.DirectionBullet * Bala.BulletForce);

            // Se invierte la rotacion del la bala para esta apunte a la direcion deseada
            BalaRigy.rotation *= -1;

            // Se cambia el Layer de la bala, esto se hacer para que pueda hacerle daño al jugador
            Bala.gameObject.layer = 13;
        }

        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        if (Player != null)
        {
            Player.CurrentLife -= 1;
        }
    }
}
