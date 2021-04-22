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

    public void DeshabilitarInstrucciones() {
        // Apagar instrucciones.
        this.transform.GetChild(22).gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Mostrar instrucciones.
        this.transform.GetChild(22).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
