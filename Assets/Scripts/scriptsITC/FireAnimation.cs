using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script administra la animacion y respuesta del fuego dentro del nivel 3 del Robot.
Revisa si el personaje lo apaga o si aparece en una zona del suelo, por lo que desaparece

Autor: Joan Daniel Guerrero Garcia
*/

public class FireAnimation : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Extintor") || other.gameObject.CompareTag("Piso"))
        {
            Game_Controller.instance.fuegos_activos -= 1;
            Destroy(gameObject);
            //Debug.Log("Fuego apagado!");
        }
    }
}
