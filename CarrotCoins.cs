using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrotCoins : MonoBehaviour
{
    private Text CarrotText;

    private void Awake()
    {
        // En el HUB hay un contador que indica el numero de monedas recogias
        // Se toma referencia del componente Text
        CarrotText = GameObject.Find("CarrotCoinsText").GetComponent<Text>();
    }

    // Cuando un objeto toca la moneda
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Se comprueba que el jugador haya tocado la moneda
        if (Player != null)
        {
            // Se suma 1 al contador
            Player.Count += 1;

            // Se cambia el texto del contador
            CarrotText.text = "X " + Player.Count;

            // Se destruye
            Destroy(gameObject);
        }
    }
}
