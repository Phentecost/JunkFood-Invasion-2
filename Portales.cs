using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portales : MonoBehaviour
{
    public GameObject PortalS;
    private float Counter = 0;

    private void Update()
    {
        // Se creo un cronometro, ese indica el tiempo que permanece inactivo el componente de BoxCollider2D del portal
        // Si el cronometro es menor a 0
        if (Counter <= 0)
        {
            // Se activa el componente de BoxColider2D del portal de salida
            PortalS.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (Counter > 0)
        {
            // El cronoemtro disminuye con el timpo
            Counter -= Time.deltaTime;
        }
    }

    // Cuando un objeto entre en el portal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.GetComponent<PlayerController>();

        // Se comprueba que el jugador haya pasado por el portal
        if (Player != null)
        {
            // Se cambia la posicion del jugador a la posicion del portal de salida
            Player.gameObject.transform.position = PortalS.transform.position;

            // Se asigna un tiempo para el cronometro
            Counter = 2.0f;

            // Se desactiva el componente de BoxColaider2D del portal de salida
            PortalS.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
