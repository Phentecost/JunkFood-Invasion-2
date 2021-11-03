using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gota : MonoBehaviour
{
    // Cuando la gota toque otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que la gota haya tocado al jugador
        if (Player != null)
        {
            // Se cambia la vida del jugador
            Player.CurrentLife -= 1;
        }

        // Se destruye
        Destroy(gameObject);
    }
}
