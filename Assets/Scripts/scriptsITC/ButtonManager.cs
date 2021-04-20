using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script controla la navegacion dentro del panel de instrucciones del nivel 3 del Robot.
Su funcion es cambiar de pagina con los botones de derecha e izquierda y mostrar/ocultar 
los botones con respecto a la pagina en la que esten. Actualmente funciona con 3 paginas.

Autor: Joan Daniel Guerrero Garcia
*/

public class ButtonManager : MonoBehaviour
{
    public GameObject boton_izq;            // Boton para pagina anterior
    public GameObject boton_der;            // Boton para pagina siguiente

    public GameObject texto1;               // Texto de la pagina 1
    public GameObject texto2;               // Texto de la pagina 2
    public GameObject texto3;               // Texto de la pagina 3

    private int pagina = 0;                 // Valor de la pagina actual
    private bool subiendo = true;

    bool inputAvanzar;

    void Update()
    {
        inputAvanzar = Input.GetButtonDown("Jump");
        if (inputAvanzar)
        {
            if (subiendo)
            {
                Avanzar();
            }
            else
            {
                Retroceder();
            }
        }
    }

    public void Avanzar()                   // Se mueve hacia la pagina siguiente
    {
        pagina++;
        gameObject.transform.GetChild(pagina).gameObject.SetActive(true);
        gameObject.transform.GetChild(pagina - 1).gameObject.SetActive(false);
        boton_izq.SetActive(true);
        subiendo = true;
        if (pagina == 5)
        {
            boton_der.SetActive(false);
            subiendo = false;
        }
        print(pagina);
    }

    public void Retroceder()            // Se mueve hacia la pagina anterior
    {
        pagina--;
        gameObject.transform.GetChild(pagina).gameObject.SetActive(true);
        gameObject.transform.GetChild(pagina + 1).gameObject.SetActive(false);
        boton_der.SetActive(true);
        subiendo = false;
        if (pagina == 0)
        {
            boton_izq.SetActive(false);
            subiendo = true;
        }
        print(pagina);
    }
}
