using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script revisa si el personaje entra en contacto con alguna zona con el tag piso

Autor: Joan Daniel Guerrero Garcia
*/

public class is_grounded_controller : MonoBehaviour
{
    public static bool is_grounded;
    public static bool is_landing;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piso"))
        {
            is_grounded = true;
            //print("Esta en piso");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piso"))
        {
            is_grounded = false;
            //print("No esta en piso");
        }
    }
}
