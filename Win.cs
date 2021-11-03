using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    public CanvasManager CanMan;

    // Al final de cada nivel hay un objeto que, cuando el jugador lo atraviesa, gana.
    // Cuando un objeto lo atraviesa 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el jugador lo haya atravesado 
        if (Player != null)
        {
            // Se le envia una señal al C# del Canvas Manager que active la pantalla de victoria
            CanMan.Ganaste = true;
        }
    }
}
