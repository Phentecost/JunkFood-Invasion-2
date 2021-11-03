using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulets : MonoBehaviour
{
    private void Update()
    {
        // Se destruye el proyectil después de 3 segundos
        Destroy(gameObject, 3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cuando las balas del jefe impacten en el jugador, este pierde vida
        // Se toma referencia del C# del Jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();
        if (Player != null)
        {
            // Se cambia la vida del jugador
            Player.ChangeLife(-1);
            Destroy(gameObject);
        }

        // Cuando las balas del jefe impacten contra las balas del jugador, ambas se destruyen
        // Se toma referencia del C# de las balas del jugador
        Bullets B = collision.gameObject.GetComponent<Bullets>();
        if (B != null)
        {
            // Se destruye
            Destroy(gameObject);
        }
    }
}
