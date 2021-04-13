using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script se utiliza para las llaves que haya en el nivel 3 del Robot.
Revisa si el personaje entra en el collider del objeto, y si si, la recoge 
y desbloquea la zona correspondiente

Autor: Joan Daniel Guerrero Garcia
*/

public class Key_level : MonoBehaviour
{
    public LevelGateAnimation level_gate;       // Puerta de nivel que abre esta llave

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GetComponent<SpriteRenderer>().enabled = false;

            //Debug.Log("Llave encontrada!!");
            level_gate.Open();
            Destroy(gameObject);
        }
    }
}
