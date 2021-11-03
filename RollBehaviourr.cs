using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehaviourr : StateMachineBehaviour
{
    // El Comportamiento de Roll es cuando el jefe se ubica en un punto especifico y se desplaza, rodando, hacia otro punto, y se devuelve. 

    private Vector3 Inicio;
    private Vector3 Final;
    public Vector3 MoverHacia;
    public float Speed;

    /* El comportamiento de Roll es un ciclo de ida y de vuelta, se crea un bool para comprobar que el jefe realizo una trayectoria de ida,
    y se coloca true cuando este realizando la trayectoria de vuelta*/
    private bool Giro = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Se toma referencia del punto en donde inicia el comportamiento
        Inicio = GameObject.FindGameObjectWithTag("Inicio").transform.position;

        // Se toma referencia del punto donde termina el comportamiento
        Final = GameObject.FindGameObjectWithTag("Final").transform.position;

        // Se coloca al jefe en el punto deseado
        animator.transform.position = Inicio;

        // Se define hacia donde se quiere trasladar el jefe 
        MoverHacia = Final;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Se utiliza la funcion MoveTowards para mover el jefe hacia la direcion desea indicando su punto de inicio y su velocidad
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, MoverHacia, Speed * Time.deltaTime);

        // Cuando el jefe llegue al punto final
        if (animator.transform.position == Final)
        {
            // Se cambia la posicion a donde se quiere trasladar, en este caso el jefe se va a devolver
            MoverHacia = Inicio;

            // Se toma referencia de las componentes de escala del jefe
            Vector3 Scalator = animator.transform.localScale;

            // La se multiplica la componente escalar x del jefe por -1, esto se hace para "darle la vuelta"
            Scalator.x *= -1;

            // Se asignan las variables
            animator.transform.localScale = Scalator;

            // Se cambia el bool a True
            Giro = true;
        }

        // cuando el jefe finalice la trayectoria de vuelta
        if (animator.transform.position == Inicio && Giro == true)
        {
            // Se realiza el mismo procedimiento que antes
            Vector3 Scalator = animator.transform.localScale;
            Scalator.x *= -1;
            animator.transform.localScale = Scalator;

            // Se le indica al Animator que transicione al estado de Idle
            animator.SetTrigger("Idle");
        }
      
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Se cambia el destino el jefe, se hace para evitar errores o comportamientos no deseados
        MoverHacia = Final;
    }

}
