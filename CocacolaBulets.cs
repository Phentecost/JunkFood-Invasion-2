using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocacolaBulets : MonoBehaviour
{
    private Rigidbody2D Rigy;
    private Transform PlayerTF;
    void Start()
    {
        // Se toma referencia del componente Rigibody2D
        Rigy = GetComponent<Rigidbody2D>();

        // Se toma referencia de la posicion del jugador
        PlayerTF = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // La inencion es que las balas calleran en la posicion del jugador pero no salio como se tenia previsto

        // Se crea un vector que parta desde la posicion del enemigo hacia la posicion del jugador
        Vector2 FireDirection = PlayerTF.position - transform.position;

        // Se utiliza la funcion Atan2 para calcular el angulo del vector con respecto al eje x
        float Angulo = Mathf.Atan2(FireDirection.y, FireDirection.x)* Mathf.Rad2Deg;

        // Se rotan las balas con Respecto al angulo encontrado
        transform.rotation = Quaternion.AngleAxis(-Angulo, Vector3.forward);
    }

    // Cuando las balas choquen on un objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se toma referencia del C# del jugador
        PlayerController Player = collision.gameObject.GetComponent<PlayerController>();

        // Si la bala choco con el jugador
        if (Player != null)
        {
            // Se cambia la vida del jugador
            Player.ChangeLife(-1);
        }

        // La bala se destruye
        Destroy(gameObject);
    }
}
