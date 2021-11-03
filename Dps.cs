using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dps : MonoBehaviour
{
    float time = 8;
  
    // Cuando un objeto lo toca
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se toma referencia del C# del jugador 
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el jugador haya tocado el onjeto
        if (Player != null)
        {
            // Se activa el DPS
            Player.dps = true;

            // Se le envia un tiempo al C# del jugador
            Player.timer = time;
            
        }

        // Se destruye 
        Destroy(gameObject);
    }
}
