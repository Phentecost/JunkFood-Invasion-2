using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolverAJugar : MonoBehaviour
{
    public Fundido FundidoI;

    // Se llama a la funcion de volver a jugar cuando se quiera reiniciar un nivel
    public void VolverAJugarV(string Ecena)
    {
        // Se llama a la funcion FundirA del C# Fundido
        FundidoI.FundirA();

        // Se inicia una Corrutina y se le envia un variable de Escena
        StartCoroutine(CambioDeNivelC(Ecena));
    }

    // Corrutina
    IEnumerator CambioDeNivelC(string Ecena)
    {
        // Se espera 1 segundo
        yield return new WaitForSeconds(1);

        // Se inicia la escena
        SceneManager.LoadScene(Ecena);
    }
}
