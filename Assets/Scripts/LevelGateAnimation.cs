using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script maneja las puertas para pasar de cada fase dentro del nivel 3 del Robot.
Tiene metodos individuales para abrir y cerrar, cada puerta de nivel tiene una doble compuerta,
una se abre al pasar de nivel, y otra se tiene que abrir para iniciar la siguiente fase

Autor: Joan Daniel Guerrero Garcia
*/

public class LevelGateAnimation : MonoBehaviour
{
    private Game_Controller game_controller;        // GameObject del controlador

    void Start()
    {
        game_controller = FindObjectOfType<Game_Controller>();
    }

    public void Open()
    {
        GetComponent<Animator>().SetTrigger("Open");
        print("Nivel terminado!");
    }

    public void Close()
    {
        GetComponent<Animator>().SetTrigger("Close");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            // Si se quiere abrir la segunda puerta de la fase, se cierra la puerta anterior y se empieza el nivel
            if (gameObject.name == "Level_gate 1-2") {
                GameObject.Find("Level_gate 1").GetComponent<LevelGateAnimation>().Close();
                GetComponent<Animator>().SetTrigger("Open");
                print("Empieza el nivel!");
                game_controller.oleada = true;
            }
            else if (gameObject.name == "Level_gate 2-3") {
                GameObject.Find("Level_gate 2").GetComponent<LevelGateAnimation>().Close();
                GetComponent<Animator>().SetTrigger("Open");
                print("Empieza el nivel!");
                game_controller.oleada = true;
            }
        }
    }
}
