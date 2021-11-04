using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        if (Player != null)
        {
            if (Player.LlavePuerta)
            {
                CanvasManager Canva = GameObject.Find("Canvas").GetComponent<CanvasManager>();
                Canva.Ganaste = true;
            }
        }
    }

}
