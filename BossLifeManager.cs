using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeManager : MonoBehaviour
{
    public float Life;
    public int Damage;
    public Slider LifeBar;
    public CanvasManager CanV;
    void Start()
    {
        // Vida total del Jefe
        Life = 95.0f;
        // Daño del jefe
        Damage = -1;
    }


    void Update()
    {
        // La Vida del jefe se ve reflejada en un Slider en el HUB
        // Los Valores del Slider son iguales a la vida del jefe
        LifeBar.value = Life;
        if (Life <= 0 )
        {
            // Cuando la vida del jefe llegue a 0, Se destruye
            Destroy(gameObject);
            // Cuando el jefe muere, se envia una señal al C# del Canvas Manager para que active la pantalla de Victoria
            CanV.Ganaste = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cuando el jefe toca al jugador, este pierde Vida
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();
        if (Player != null)
        {
            // Se cambia la vida del jugador
            Player.ChangeLife(Damage);
        }

        // Cuando las balas del jugador golpee al jefe, este pierde vida
        // Se toma referencia del C# de las balas del jugador
        Bullets Bala = collision.gameObject.GetComponent<Bullets>();
        if (Bala != null)
        {
            // Se cambia la vida del Jefe
            Life -= Bala.Daño;
        }
    }
}
