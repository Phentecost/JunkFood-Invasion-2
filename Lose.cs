using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    // Este C# es de una plataforma invisible que esta debajo del nivel, si el jugador se cae del nivel, la toca y peirde

    // Cuando un objeto toque la plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el jugador haya tocado la plataforma
        if (Player != null)
        {
            // Se cambia la vida del jugador a 0
            Player.CurrentLife = 0;
        }
    }
}
