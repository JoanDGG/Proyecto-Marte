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
    private Game_Controller game_controller;    // GameObject que administra la cantidad de fuego presente

    void Start()
    {
        game_controller = FindObjectOfType<Game_Controller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Extintor") || other.gameObject.CompareTag("Piso"))
        {
            game_controller.fuegos_activos -= 1;
            Destroy(gameObject);
            //Debug.Log("Fuego apagado!");
        }
    }
}
