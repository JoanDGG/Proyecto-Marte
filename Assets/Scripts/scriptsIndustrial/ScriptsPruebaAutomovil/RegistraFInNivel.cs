using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script para registrar el tiempo de finalización del nivel.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 27 de abril de 2021.
 */
public class RegistraFInNivel : MonoBehaviour
{
    public void CambiaTiempoFin() {
        GameManager.tiempoFinNivel = System.DateTime.Now;
    }

    // Start is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
