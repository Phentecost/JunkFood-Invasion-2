using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papa : MonoBehaviour
{
    private Rigidbody2D PapaRigy;
    public float Speed = 5;
    private float Direction = 1;
    public Transform Check;
    public float life;


    void Start()
    {
        // Se toma referencia del componente rigidbody2D
        PapaRigy = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Se utiliza la funcion OverlapCircle para comprobar si esta tocando el suelo
        // La funcion OverlapCircle crea un circulo en la posicion x, con diametro x y este va a detectar todo objeto que se encuentra en la Layer x
        bool IsOnGround = Physics2D.OverlapCircle(Check.position, 0.2f, LayerMask.GetMask("PL"));

        // Si el enemigo no esta tocando el suelo
        if (!IsOnGround)
        {
            // Se cambia da lirecion hacia donde camina
            Direction *= -1;

            // Se toma referencia del componente escalar del enemigo
            Vector3 Scaler = transform.localScale;

            // Se multiplica el componente escalar x por -1
            Scaler.x *= -1;

            // Se asignan los valores
            transform.localScale = Scaler;
        }

        // Se utiliza la funcion velocity para mover el enemigo en una direcion deseada con una velocidad x
        PapaRigy.velocity = new Vector2(Speed * Direction, PapaRigy.velocity.y);

        // Si la vida es 0
        if (life <= 0)
        {
            // Se destruye
            Destroy(gameObject);
        }
    }

    // Cuando el enemigo choca con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el enemigo haya tocado al jugador
        if (Player != null)
        {
            // Se cambia la vida del jugador
            Player.CurrentLife -= 1;
        }
    }
}
