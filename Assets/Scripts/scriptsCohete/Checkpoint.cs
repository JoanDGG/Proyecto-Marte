using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/*
* Este script detecta si el cohete llego al checkpoint
* Autor: Daniel Garcia Barajas
*/
public class Checkpoint : MonoBehaviour
{
    public GameObject imagenPreguntas;
    public Cuestionario cuestionario;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.GetComponent<SpriteRenderer>().enabled == true){
            Time.timeScale = 0;
            GameManager.oleada += 1;
            imagenPreguntas.SetActive(true);
            cuestionario.DesbloquearPreguntas();
            GameManager.tiempoFinNivel = System.DateTime.Now;
        }

        if (collider.gameObject.CompareTag("Checkpoint-1")){
            print("Has llegado al checkpoint del nivel 1-1");
            
        }

        if (collider.gameObject.CompareTag("Checkpoint-2")){
            print("Has llegado al checkpoint del nivel 1-2");
            
        }

        if (collider.gameObject.CompareTag("Checkpoint-3")){
            print("Has llegado al checkpoint del nivel 1-3");
        }
    }
}
