using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public GameObject Inicio;
    public GameObject Selector;
    public string[] Niveles;
    public Fundido FundidoI;

    // La Funcion Cambio De Pantallas se llama cada ves que se queira pantallas en unity
    // Para cambiar de escenas se tiene una transicion que es un fundido
    public void CambioDePantallas()
    {
        // Se llama a la funcion FundidrA del C# Fundido
        FundidoI.FundirA();

        // Se inicia una Corrutina
        // Una Corrutina es una funcion que ejecuta un codigo con un delay que controla el programador
        StartCoroutine(CambioDePantallasC());
    }

    //Corrutina
    IEnumerator CambioDePantallasC()
    {
        // Se espera 1 segundo
        yield return new WaitForSeconds(1);

        // Se desactiva el panel de inicio
        Inicio.SetActive(false);

        // Se activa el panel de Selector
        Selector.SetActive(true);

        // Se llama a la funcion de Fundir del C# Fundido
        FundidoI.Fundir();
    }


    // Se llama a la funcion Cambio de Nivel Cuando se quiera cambiar de nivel
    public void CambioDeNivel(int S)
    {
        // Se llama a la funcion FundirA del C# Fundido
        FundidoI.FundirA();

        // Se inicia una Corrutina y se le pasa un valor s
        StartCoroutine(CambioDeNivelC(Niveles[S]));
    }

    // Corrutina
    IEnumerator CambioDeNivelC(string Ecena)
    {
        // Se espera 1 segundo
        yield return new WaitForSeconds(1);

        // Se Cambia al nivel S
        SceneManager.LoadScene(Ecena);
    }
}
