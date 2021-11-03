using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public float Speed;
    public float Life = 10;
    private Rigidbody2D DonutRigy;
    private float Direction;
    private bool Check = false;
    private bool Movement = false;
    private Animator DonutAnim;
    void Start()
    {
        // Se toma referencia del componente del rigibody2D
        DonutRigy = GetComponent<Rigidbody2D>();

        // Se toma referencia del Animator
        DonutAnim = GetComponent<Animator>();
    }


    void Update()
    {
        // Se tiene un bool que hace indica si el enemigo detecto al jugador
        // Si el la dona no detecta al jugador
        if (!Check)
        {
            // Se crea un rayo, que parta del enemigo hacia la derecha, con una longitud x y que detecto al jugador
            RaycastHit2D HitRight = Physics2D.Raycast(DonutRigy.position, Vector2.right, 5, LayerMask.GetMask("Jugador"));

            // Si el rayo detecto al jugador
            if (HitRight.collider != null)
            {
                // Se indica la direcion hacia donde se debe mover
                Direction = 1;

                // Se toma referencia de la componente Escalar del enemigo
                Vector3 Scalor = transform.localScale;

                // Se multiplica la componete Escalar x, esto se hace para girar el enemigo
                Scalor.x *= 1;

                // Se asignan los valores
                transform.localScale = Scalor;

                // Se cambia el bool a True
                Check = true;

                // Se indica al enemigo que ya se puede mover
                Movement = true;

                // Se inicia la animacion de Roll
                DonutAnim.SetTrigger("Roll");
            }

            // lo Mismo pero hacia la izquierda
            RaycastHit2D HitLeft = Physics2D.Raycast(DonutRigy.position, Vector2.left, 5, LayerMask.GetMask("Jugador"));
            if (HitLeft.collider != null)
            {
                Direction = -1;
                Vector3 Scalor = transform.localScale;
                Scalor.x *= -1;
                transform.localScale = Scalor;
                Check = true;
                Movement = true;
                DonutAnim.SetTrigger("Roll");
            }
        }

        // Se tiene un bool que le dice al enemigo cuando se puede mover
        // Si el enemigo se puede mover
        if (Movement)
        {
            // se utiliza la funcion Velocity para mover el enemigo en la direcion deseada con una velocidad x
            DonutRigy.velocity = new Vector2(Speed * Direction, DonutRigy.velocity.y);
        }

        // Si la vida es 0
        if (Life <= 0)
        {
            // Se destruye
            Destroy(gameObject);
        }
    }

    // Cuando el enemigo choca contra un objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el enemigo haya chocado con el jugador
        if (Player != null)
        {
            // Se cambia la vida del jugador
            Player.CurrentLife -= 1;

            // Se destruye        
            Destroy(gameObject);
        }
    }

}
