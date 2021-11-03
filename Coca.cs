using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coca : MonoBehaviour
{
    private Rigidbody2D CocaRigy;
    public float Speed;
    private float Direction = 1;
    public Transform Check;
    public Transform FirePoint;
    public GameObject BulletPF;
    public float FirePower;
    private float FireTimer;
    public float life;
    void Start()
    {
        // Se toma referencia del componente Rigidbosy2D
        CocaRigy = GetComponent<Rigidbody2D>();

        // Se crea un cronometro, este indica el tiempo se tarda en disparar
        FireTimer = 0;

        // Vida maxima
        life = 20;
    }

    void Update()
    {
        // Se utiliza la funcion OverlapCircle para comprobar si esta tocando el suelo
        // La funcion OverlapCircle crea un circulo en la posicion x, con diametro x y este va a detectar todo objeto que se encuentra en la Layer x
        bool IsOnGround = Physics2D.OverlapCircle(Check.position, 0.2f, LayerMask.GetMask("PL"));

        // Cuando la Coca no este tocando el suelo
        if (!IsOnGround)
        {
            // Se cambia la direcion hacia donde camina
            Direction *= -1;

            // Se toma referencia la componente Escalar
            Vector3 Scaler = transform.localScale;

            // Se multiplica la componente Escalar x, esto se hace para girar el enemigo
            Scaler.x *= -1;

            // Se asignan los valores
            transform.localScale = Scaler;
        }

        // Se utiliza la funcion velocity para mover el personaje en la direcion deseada con una velocidad x
        CocaRigy.velocity = new Vector2(Speed * Direction, CocaRigy.velocity.y);

        // Si la vida del enemigo es 0
        if (life <= 0)
        {
            // Se destruye
            Destroy(gameObject);
        }
    }

    // La funcion Shoot se llama cada vez que el enemigo dispare
    public void Shoot()
    {
        // Cuando el tiempo de disparo sea 0
        if (FireTimer <= 0)
        {
            // Se crea una bala
            GameObject Bullet = Instantiate(BulletPF, FirePoint.position, FirePoint.rotation);

            // Se utiliza la funcion velocity para disparar la bala
            Bullet.GetComponent<Rigidbody2D>().velocity = transform.up * FirePower;

            // Se reinicia el cronometro
            FireTimer = 0.5f;
        }
        if (FireTimer >= 0)
        {
            // El cronometro disminuye con el tiempo
            FireTimer -= Time.deltaTime;
        }
    }

    // El enemigo posee un area triger, esta area es su rango de disparo
    // Cuando algo entre en su rango de disparo
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se compureba que el jugador alla entrado en el rango de disparo
        if (Player != null)
        {
            // Se llama a la muncion de Shoot
            Shoot();
        }
    }

    // Cuando un objeto toca al enemigo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el jugador alla tocado al enemigo
        if (Player != null)
        {
            // Se cambia la vida del jugador
            Player.CurrentLife -= 1;
        }
    }
}
