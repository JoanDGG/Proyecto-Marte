using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Importo el módulo de Unity para cambiar de escena.
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    /*
    Script que contiene la función asociada al botón para probar al automóvil en acción en otra escena.
    Autor: Luis Ignacio Ferro Salinas A01378248
    Última actualización: 14 de abril de 2021
    */

    public void ProbarAuto()
    {
        SceneManager.LoadScene("PreguntasNivelIndustrial"); 
    }
}
