using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fundido : MonoBehaviour
{

    private Image FundidoI;
    void Start()
    {
        // El Fundido es una imagen que cambia sus valores de trasparencia con el fin de servir como transicion
        // Se toma referencia del componente Image
        FundidoI = GetComponent<Image>();

        // Se utliza la funion CrossFadeAlpha para cambiar el valor de Alpha a otro durante x segundos
        FundidoI.CrossFadeAlpha(0, 0.5f, false);
    }

    // Se llama la funcion Fundir Cuando se quiere poner transparente la imagen
    public void Fundir()
    {
        // Se utliza la funion CrossFadeAlpha para cambiar el valor de Alpha a otro durante x segundos
        FundidoI.CrossFadeAlpha(0, 0.5f, false);
    }

    // Se llama la funcion FundirA cuando se quiere poner negra la imagen
    public void FundirA()
    {
        // Se utliza la funion CrossFadeAlpha para cambiar el valor de Alpha a otro durante x segundos
        FundidoI.CrossFadeAlpha(1, 0.5f, false);
    }
}
