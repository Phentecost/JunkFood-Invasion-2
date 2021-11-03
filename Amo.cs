using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amo : MonoBehaviour
{

    private Image AmoGRX;
    public Sprite[] AmoI;
    void Start()
    {
        // En el HUB se tiene una barra que indica la cantidad de municion que le queda al jugador
        // Se toma referencia del componente de Image
        AmoGRX = GetComponent<Image>();
    }

    void Update()
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = GameObject.Find("Character").GetComponent<PlayerController>();

        // Se cambia la imagen del HUB dependeindo de la municion del jugador
        AmoGRX.sprite = AmoI[Player.Amo/2];
    }
}
