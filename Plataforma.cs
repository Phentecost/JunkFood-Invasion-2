using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float Speed;
    public Transform Inicio;
    public Transform Final;
    private Vector2 Target;
    public GameObject Plat;

    // Funcio que se ejecuta antes del void start
    private void Awake()
    {
        // Se coloca la plataforma en la posicion deseada
        Plat.transform.position = Inicio.position;

        // Se asigna un destino
        Target = Final.position;
    }
    
    void Update()
    {
        // Se utiliza la funcion MoveTowards para mover la plataforma desde su origen hacia un punto especifico con una velocidad x
        Plat.transform.position = Vector2.MoveTowards(Plat.transform.position, Target, Speed * Time.deltaTime);

        // Si la plataforma llego a su destino
        if (Plat.transform.position == Final.position)
        {
            // Se Devuelve
            Target = Inicio.position;
        }

        // Si la plataforma llego a su destino
        if (Plat.transform.position==Inicio.position)
        {
            // Se devuelve
            Target = Final.position;
        }
    }
}
