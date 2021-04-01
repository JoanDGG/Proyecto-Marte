using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script maneja la animacion de las puertillas dentro del nivel 3 del Robot.
Tiene funciones individuales para abrir y cerrar y tambien responde al personaje

Autor: Joan Daniel Guerrero Garcia
*/

public class GateAnimation : MonoBehaviour
{
    public static bool is_open;
    private Game_Controller game_controller;
    
    void Start()
    {
        is_open = false;
        game_controller = FindObjectOfType<Game_Controller>();
    }

    public void Open()
    {
        if (!is_open)
        {
            GetComponent<Animator>().SetTrigger("Open");
            is_open = true;
            game_controller.puertas_abiertas += 1;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void Close()
    {
        if (is_open)
        {
            GetComponent<Animator>().SetTrigger("Close");
            is_open = false;
            game_controller.puertas_abiertas -= 1;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            if (!is_open)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }
}
