using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public Rigidbody2D BulletRigy;
    public float Daño;
    public Vector2 DirectionBullet;
    public float BulletForce;

    // La funcion FireBullet se llama cuando el jugador dispara una bala
    public void FireBullet(Vector2 Direction , float Force, float Damage)
    {
        // Se utiliza la funcion AddForce para disparar la bala en la direcion deseada, con una velocidad x
        BulletRigy.AddForce(Direction * Force);

        // Se destruye despues de 5 segundos
        Destroy(gameObject, 5);

        // Se almacena la direccion
        DirectionBullet = Direction;

        // Se almacena la velocidad/fuerza
        BulletForce = Force;

        // Se almacena el daño
        Daño = Damage;
    }

    // Cuando la bala impacta contra un objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# de la dona
        Donut Dona = collision.gameObject.GetComponent<Donut>();

        // Se comprueba que la bala haya impactado en la dona
        if (Dona != null)
        {
            // Se cambia la vida de la dona
            Dona.Life -= Daño;
        }

        // Se toma referencia del C# de la Coca
        Coca CocaCO = collision.gameObject.GetComponent<Coca>();

        // Se comprueba que la bala haya impactado en la Coca Cola
        if (CocaCO != null)
        {
            // Se cambia la vida de la Coca Cola
            CocaCO.life -= Daño;
        }

        // Se toma referencia del C# de la Papa
        Papa papa = collision.gameObject.GetComponent<Papa>();

        // Se comprueba que la bala haya impactado en la Papa
        if (papa != null)
        {
            // Se cambia la vida de la Papa
            papa.life -= Daño;
        }

        // Se toma referencia del C# del Jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que la bala haya impactado en el jugador
        if (Player != null)
        {
            // Se cambia la vida del Jugador
            // Se pone (int) al frente del daño para combertirlo a un int, ya que es un float
            Player.CurrentLife -= (int)Daño;
        }

        // Se toma referencia del C# de la barra de chocolate
        Chocolate Choco = collision.gameObject.GetComponent<Chocolate>();

        // Se comprueba que la bala haya impactado en la barra de chocolate
        if (Choco != null)
        {
            // Se termina la ejecucion de este frame
            return;
        }
        Destroy(gameObject);
    }
}
