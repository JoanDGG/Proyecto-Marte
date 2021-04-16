using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonContinuar : MonoBehaviour
{
    public GameObject Resultados;
    public void MostrarResultados()
    {
        if(Game_Controller.instance.nivel == 4)
        {
            Resultados.SetActive(true);
        }
    }
}
