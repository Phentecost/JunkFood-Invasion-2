using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D PlayerRigy;
    public float Speed;
    public float Jump;
    public float HorizontalMove;

    private bool FacingRigth = false;

    public bool IsGrounded;
    public Transform GroundCheck;
    private float CheckRadius = 0.5f;
    public LayerMask Ground;

    public GameObject Bullet;
    public Transform Firepoint;

    public int  Life = 4;
    public int CurrentLife;

    public int Amo;

    public int Count;

    public Animator PlayerAnim;

    public bool PANEL;

    private float FireAngle;
    private Vector2 MouseP;
    private Vector2 LookD;
    public Transform FireAncle;

    private int JumpsCounts = 1;

    public bool dps;
    public float timer;
    public float Daño = 4;


    void Start()
    {
        // Se toma referencia del componente rigidbody2D
        PlayerRigy = GetComponent<Rigidbody2D>();

        // Se tienen dos variables, Life indica la vida maxima del jugador, CurrentLife indica la vida actual del jugador
        // Se asigna la vida maxima a la vida actual
        CurrentLife = Life;

        // Se asigna la municion del jugador
        Amo = 18;

        // Se asigna los puntos del jugador
        Count = 0; 

    }


  
    // El Void FixedUpdate es un Update que se especializa en manejar las fisicas de unity
    private void FixedUpdate()
    {
        // Se tiene un bool que indica que el HUB esta mostrando un panel, ya sea de pausa, panel de victoria, panel de derrotam etc.
        // Si el HUb esta mostrando un panel
        if (PANEL)
        {
            // Termine la ejecucion de este frame
            return;
        }

        // Se utiliza la funcion OverlapCircle para comprobar si esta tocando el suelo
        // La funcion OverlapCircle crea un circulo en la posicion x, con diametro x y este va a detectar todo objeto que se encuentra en la Layer x
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, Ground);

        // Se almacena la informacion de los inputs horizontales
        HorizontalMove = Input.GetAxisRaw("Horizontal");

        // Se utiliza la funcion velocity para mover al personaje en una direcion deseada con una velocidad x
        PlayerRigy.velocity = new Vector2(HorizontalMove * Speed, PlayerRigy.velocity.y);
        
        // Se tiene un bool que indica si el jugador esta mirando hacia la derecha
        // Si el jugador no esta mirando a la derecha y la informacion del input horizontal es mayor a 0
        if (FacingRigth ==false && HorizontalMove >0)
        {
            // Se llama a la funcion de Flip
            Flip();
        }

        // Si el jugador esta mirando hacia la derecha y la informacion del input horizontal es menor a 0
        else if (FacingRigth == true && HorizontalMove < 0) 
        {
            // se llama a la funcio de flip
            Flip();
        }
    }

    void Update()
    {
        // Si el HUB esta mostrando un panel
        if (PANEL)
        {
            // Termina la ejecucion de este frame
            return;
        }

        // El jugador puede disparar en todas las direciones, utilizando el cursor del mouse para apuntar
        // Se Almacena la posicion del mouse utilizando la funcion ScreenToWorldPoint
        // Esta funcion reconoce la posicion del mouse en una pantalla, es decir, en un plano en terminos de pixeles, y la transforma en unidades de medida de unity
        MouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        // Se crea un vector que parta de la posicion del jugador hacia la posicion del mouse
        LookD = MouseP - PlayerRigy.position;

        // Se utiliza la funcion Atan2 para encontrar el angulo que forma el vector encontrado con respecto al eje x
        FireAngle = Mathf.Atan2(LookD.y, LookD.x) * Mathf.Rad2Deg - 180f;

        // Se rota el punto de fuego, o de donde parten las balas del jugador, con respecto al angulo encontrado
        FireAncle.rotation = Quaternion.Euler(0, 0, FireAngle);

        // El jugador tiene la posibilidad de saltar 2 veces
        // si el jugador esta en el suelo
        if (IsGrounded)
        {
            // El conteo de saltos en el aire permitidos es 1
            JumpsCounts = 1;
        }

        // Si se presiona la tecla espacio y el contador de saltos es mayor a 0
        if (Input.GetButtonDown("Jump") && JumpsCounts > 0)
        {
            // Se utiliza la funcion velocity para impulsar el jugador 
            PlayerRigy.velocity = Vector2.up * Jump;

            // Se resta en 1 el contador de saltos
            JumpsCounts --;
        }

        // Si se presiona el click izquierdo y la municion del jugador es mayo o igual a 1
        if (Input.GetMouseButtonDown(0) && Amo >= 1)
        {
            // Se llama a la funcion de Fire
            Fire();

            // Se resta en 1 la municion 
            Amo -= 1;
        }

        // Se tiene un bool que determina si esta activo el estado de DPS
        // Se tiene un cronometro que determina la duracion del estado de DPs
        // Si DPS esta activo y el cronometro es mayor que 0
        if (dps && timer > 0)
        {
            // El daño del jugador es 10
            Daño = 10;

            // El cronometro disminuye con el tiempo
            timer -= Time.deltaTime;
        }

        // Si el cronometro es menor que 0
        else if (timer <= 0) 
        {
            // El estado de DPS esta desactivado
            dps = false;
        }

        if (HorizontalMove < 0 || HorizontalMove > 0)
        {
            PlayerAnim.SetBool("OnMovement",true);
        }
        else 
        {
            PlayerAnim.SetBool("OnMovement", false);
        }

    }

    // La funcion de Flip se llama cada ves que se quiere girar el personaje
    void Flip()
    {
        // Se invierte el bool
        FacingRigth = !FacingRigth;

        // Se toma referencia del componente escalar del jugador
        Vector2 Scaler = transform.Find("Player GF").localScale;

        // Se multiplica el componente escalar x por -1
        Scaler.x *= -1;

        // Se aplican las variables
        transform.Find("Player GF").localScale = Scaler;
    }

    // La funcion Fire se llama cada vez que el jugador dispara
    void Fire()
    {
        // Se crea una bala
        GameObject BulletPF = Instantiate(Bullet, Firepoint.position, FireAncle.rotation);

        // Se toma referencia del C# de las balas del jugador
        Bullets BulletSC = BulletPF.GetComponent<Bullets>();

        // Se llama a la funcion FireBullet y se le envia ciertos datos
        BulletSC.FireBullet(-Firepoint.right, 1000,Daño);
    }

    // La funcion Change life se llama cada ves que el jugador pierde o gane vida
    public void ChangeLife(int amount)
    {
        // Se utiliza la funcion MathF.CLamp para mantener la vida del jugador en un intervalo definido
        // Se cambia la vida del jugador
        CurrentLife = Mathf.Clamp(CurrentLife + amount, 0, Life);
    }

    // Cuando el jugador toque un objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se comprueba que el objeto sea una plataforma
        if (collision.gameObject.tag=="Plat")
        {
            // Se asigna al jugador hijo de la plataforma
            transform.parent = collision.transform;
        }
    }

    // Caudno el jugador deje de tocar un objeto
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Se comprueba que el objeto sea una plataforma
        if (collision.gameObject.tag == "Plat")
        {
            // Se quita la asignacion de padre
            transform.parent = null;
        }
    }

    // La funcion change Amo Se llama cada ves que el jugador tome una caja de municion
    public void ChangeAmo(int Amount)
    {
        // Se utiliza la funcion MathF.CLamp para mantener la municion del jugador en un intervalo definido
        // Se cambia la municion
        Amo = Mathf.Clamp(Amo + Amount, 0, 18);
    }
   
}
