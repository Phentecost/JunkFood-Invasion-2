using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : StateMachineBehaviour
{

    // El comportamiento es Fire es cuando el jefe se coloca en una posicion especifica y este empieza a disparar hacia el jugador.

    private Transform FirePoint;
    public GameObject BLT;
    private Transform FirePosition;
    public float FirePower;
    private float Timer;
    private float FireTimer;

    // Cuando se crea un C# para agregar comportamiento a las animaciones, este toma referencia del Animator, AnimatorStateInfo y del LayerIndex
    // OnStateEnter = Void Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Se toma referencia de la posicion en donde el jefe se va a ubicar para disparar
        FirePosition = GameObject.FindGameObjectWithTag("Inicio").transform;

        // Se toma referencia del punto en donde salen las balas
        FirePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;

        // Se ubica al jefe en la posicion deseada
        animator.transform.position = FirePosition.position;

        // Se define un cronometro que indica la duracion del comportamiento
        Timer = 5.0f;

        // Se define un cronometro que indica el tiempo que se tarda en hacer cada disparo
        FireTimer = 0.3f;
    }

    // OnStateUpdate = Void Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Mienytas que el tiempo del comportamiento no sea 0 y el tiempo de disparo sea 0, el jefe dispara
        if (FireTimer <= 0 && Timer >= 0)
        {
            // Se crea una bala
            GameObject Bullet = Instantiate(BLT, FirePoint.position, FirePoint.rotation);

            // Se utiliza la funcion Rigidbody2d.velocity para dacirle a la bala la direcion de disparo y la velocidad del mismo
            Bullet.GetComponent<Rigidbody2D>().velocity = -FirePoint.right * FirePower;

            // Se reinicia el cronometro 
            FireTimer = 0.3f;
        }

        // Ambos cronometros disminuyen con el tiempo
        FireTimer -= Time.deltaTime;
        Timer -= Time.deltaTime;

        //Cuando el cronometro del comportamiento sea 0, Se cambia de comportamiento
        if (Timer <= 0)
        {
            // Se le indica al Animator que inicio el estado de Idle
            animator.SetTrigger("Idle");
        }
    }


}
