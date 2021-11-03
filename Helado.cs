using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helado : MonoBehaviour
{
    public float Speed;
    Rigidbody2D HeladoRigy;
    float timer;
    int Direccion = 1;
    public GameObject Bullet;
    public Transform FirePont;
    private float FireTimer;

    private void Awake()
    {
        // Se toma referencia del componente rigibody2D
        HeladoRigy = GetComponent<Rigidbody2D>();

        // Se crea un cronometro, este indica el tiempo que tarda en disparar
        FireTimer = 1;
    }


    void Update()
    {
        // Se utiliza la funcion velocity para mover el enemigo en la direcion deseada y con una velocidad x
        HeladoRigy.velocity = new Vector2(Speed * Direccion, HeladoRigy.velocity.y);

        // Se tiene un cronometro, este indica el tiempo que se desplaza en una direcion especifica, cuando el cronometro llegue a 0, se cambia la direcion del movimiento.
        // Cando el cronometro sea 0
        if (timer <= 0)
        {
            // Se reinicia el cronometro
            timer = 2.0f;

            // Se cambia de direcion
            Direccion *= -1;

            // Se toma referencia de la componete escalar del enemigo
            Vector3 Scaler = transform.localScale;

            // Se multiplica la componente escalar x por -1
            Scaler.x *= -1;

            // Se asignan los valores
            transform.localScale = Scaler;
        }
        else
        {
            // El cronometro disminuye con el tiempo
            timer -= Time.deltaTime;
        }

    }

    // La funcion Shoot se llama cada ves que el enemigo dispara
    void Shoot()
    {
        // Se el tiempo de disparo es 0
        if (FireTimer <= 0)
        {
            // Se crea una bala
            Instantiate(Bullet, FirePont.position, FirePont.rotation);

            // Se reinicia el cronometro
            FireTimer = 1;
        }
        else
        {
            // el cronometro disminuye con el timepo
            FireTimer -= Time.deltaTime;
        }

    }

    // Se tiene un circulo triger, esta es su area de disparo
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Se toma referencia al C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el jugador haya entrado en el area de disparo
        if (Player != null)
        {
            // se llama a la funcion Shoot
            Shoot();
        }
    }
}
