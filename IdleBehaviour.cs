using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    // El estado de Idle es cuando el jefe esta quieto y se le da la oportunidad de que el jugador le dispare, se utiliza este estado para transicionar a otros.

    public float Timer;
    public float MinTime;
    public float MaxTime;
    public int Rand;

    // Cuando se crea un C# para agregar comportamiento a las animaciones, este toma referencia del Animator, AnimatorStateInfo y del LayerIndex
    // OnStateEnter = Void Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Se crea un cronometro que indica la duracion del comportamiento, este dura un tiempo x
        Timer = Random.Range(MinTime, MaxTime);

        // Se crea un numero random, este indicara a que estado se va a transicionar
        Rand = Random.Range(1, 3);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // cuando el cronometro sea 0, el jefe cambia de comportaimiento
        if (Timer <= 0)
        {
            // Si Rand es 1
            if (Rand == 1)
            {
                // Se le indica al Animator que transicione al comportamiento de Fire
                animator.SetTrigger("Fire");
            }

            // Si Rand es 2
            if (Rand == 2)
            {
                // Se le indica al Animator que transicione al comportamiento de Roll
                animator.SetTrigger("Roll");
            }
        }
        else
        {
            // El tiempo del cronometro disminuye con el tiempo
            Timer -= Time.deltaTime;
        }
    }
    
    // OnStateExit, Este es una funcion que se ejecuta cuando se este cambiando a otro estado
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Se asigna un valor al Rand diferente de 1 o 2, se hace para evitar errores
        Rand = 0; 
    }
}


