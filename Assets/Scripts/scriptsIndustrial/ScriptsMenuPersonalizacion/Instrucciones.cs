using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script para mostrar las instrucciones al inicio del nivel.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualizacion: 21 de abril de 2021
 */

public class Instrucciones : MonoBehaviour
{

    public GameObject botonPausa;

    public void DeshabilitarInstrucciones() {
        // Apagar instrucciones.
        this.transform.GetChild(22).gameObject.SetActive(false);
        botonPausa.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Mostrar instrucciones.
        this.transform.GetChild(22).gameObject.SetActive(true);
        GameManager.nivelGlobal = 3; // actualizo el nivel global para que las preguntas que obtenga sean las correctas.
    }


}
