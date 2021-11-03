using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject Almacen;
    public GameObject PanelPerdiste;
    public GameObject PanelGanaeste;
    public bool Ganaste;
    private PlayerController Player;
    void Start()
    {
        // Se toma referencia del C# del jugador
        Player = GameObject.Find("Character").GetComponent<PlayerController>();

    }

    void Update()
    {
        /* El HUB esta compuesto por 3 cosas, el ALmacen, este contiene todos los elementos in game como la vida, los puntos, la municion etc, 
        la pantalla de perdiste y la pantalla de ganaste*/
        // Si la vida del jugador es menor o igual a 0
        if (Player.CurrentLife <= 0)
        {
            // Se desactiva el Almacen
            Almacen.SetActive(false);

            // Se activa el Panel de perdiste
            PanelPerdiste.SetActive(true);

            // Se le indica al C# del jugador que se esta mostrando un panel
            Player.PANEL = true;
        }

        // Se tiene un bool que indica que el jugador gano el juego
        //  Si el jugador gano
        if (Ganaste)
        {
            // Se desactiva el Almacen
            Almacen.SetActive(false);

            // Se le indica al C# del jugador que se esta mostrando un panel
            Player.PANEL = true;

            // Se activa el panel de ganaste
            PanelGanaeste.SetActive(true);
        }
    }
}
