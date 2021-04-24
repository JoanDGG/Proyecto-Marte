using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Script para registrar si las llantas tocan el suelo.
Autor: Luis Ignacio Ferro Salinas A01378248.
Última actualización: 23 de abril de 2021.
 */

public class RegistraSuelo : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.tocandoSueloLlantas = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.tocandoSueloLlantas = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print("llantas: " + GameManager.tocandoSueloLlantas.ToString());
    }
}
