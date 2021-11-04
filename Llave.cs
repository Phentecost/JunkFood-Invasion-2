using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        if (Player != null)
        {
            Player.LlavePuerta = true;
            Destroy(gameObject);
        }
    }
}
