using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoPickUp : MonoBehaviour
{
    // Cuando un objeto lo toca
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el jugador lo haya tocado
        if (Player != null)
        {
            // El Jugador recarga su municion
            Player.ChangeAmo(7);

            // Se destruye
            Destroy(gameObject);
        }
    }
}
