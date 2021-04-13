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

    private int pagina = 1;                 // Valor de la pagina actual

    public void Avanzar()                   // Se mueve hacia la pagina siguiente
    {
        if(pagina == 1)
        {
            texto1.SetActive(false);
            texto2.SetActive(true);
            boton_izq.SetActive(true);
        }
        else if (pagina == 2)
        {
            texto2.SetActive(false);
            texto3.SetActive(true);
            boton_der.SetActive(false);
        }
        pagina++;
    }

    public void Retroceder()            // Se mueve hacia la pagina anterior
    {
        if (pagina == 2)
        {
            texto1.SetActive(true);
            texto2.SetActive(false);
            boton_izq.SetActive(false);
        }
        else if (pagina == 3)
        {
            texto2.SetActive(true);
            texto3.SetActive(false);
            boton_der.SetActive(true);
        }
        pagina--;
    }
}
