using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image LifeGRX;
    public Sprite[] LifeI;
    // Start is called before the first frame update
    void Start()
    {
        // En el HUB hay unos corazones que indican la vida del jugador
        // Se toma referencia de la componente de Image
        LifeGRX = GetComponent<Image>();

    }

    private void Update()
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = GameObject.Find("Character").GetComponent<PlayerController>();

        // Se cambia la imagen dependiendo de la vida actual del jugador
        LifeGRX.sprite = LifeI[Player.CurrentLife];
    }

}
